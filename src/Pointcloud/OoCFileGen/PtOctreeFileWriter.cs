using Fusee.Base.Core;
using Fusee.Pointcloud.Common;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Fusee.Pointcloud.OoCFileReaderWriter
{
    public class PtOctreeFileWriter<TPoint>
    {
        private readonly string _fileFolderPath;

        /// <summary>
        /// Creates a new instance of type PtOctantFileWriter.
        /// </summary>
        /// <param name="pathToNodeFileFolder">The path the files are written to.</param>
        public PtOctreeFileWriter(string pathToNodeFileFolder)
        {
            _fileFolderPath = pathToNodeFileFolder;
        }

        /// <summary>
        /// Creates all files (meta.json, .hierarchy and .node).
        /// </summary>
        /// <param name="octree">The source octree.</param>
        /// <param name="ptAccessor">point accessor to get the actual point information.</param>
        public void WriteCompleteData(PtOctree<TPoint> octree, PointAccessor<TPoint> ptAccessor)
        {
            var watch = new Stopwatch();
            watch.Restart();

            WriteMeta(octree, ptAccessor);
            Diagnostics.Log("-------------- Write meta file: " + watch.ElapsedMilliseconds + "ms.");

            watch.Restart();
            WriteHierarchy(octree);
            Diagnostics.Log("-------------- Write hierarchy file: " + watch.ElapsedMilliseconds + "ms.");

            watch.Restart();
            octree.Traverse((PtOctantWrite<TPoint> node) =>
            {
                WriteNode(octree.PtAccessor, node);
            });
            Diagnostics.Log("-------------- Write hierarchy file: " + watch.ElapsedMilliseconds + "ms.");
        }

        /// <summary>
        /// Writes the binary encoded octree hierarchy into a file.
        /// </summary>
        /// <param name="octree">The source octree.</param>
        public void WriteHierarchy(PtOctree<TPoint> octree)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(_fileFolderPath + "\\octree.hierarchy", FileMode.OpenOrCreate)))
            {
                octree.Traverse((PtOctantWrite<TPoint> node) =>
                {
                    // write loadable properties (in which file the node's content - i.e. points - are stored)
                    bw.Write(node.Guid.ToByteArray()); // 16 bytes
                    bw.Write(node.Level);                    
                    bw.Write(node.IsLeaf);
                    //bw.Write(node.StreamPosition);

                    // write child indices (1 byte). For example: Octant has child 0 and 1: 2^0 + 2^1 = 3                   
                    byte childIndices = 0;

                    int exp = 0;
                    foreach (var childNode in node.Children)
                    {
                        if (childNode != null)
                            childIndices += (byte)System.Math.Pow(2, exp);

                        exp++;
                    }

                    bw.Write(childIndices);
                });
            }
        }

        /// <summary>
        /// Writes the meta data into a json file. Contains information about the octree and the point type of the point cloud.
        /// </summary>
        /// <param name="octree">The source octree.</param>
        /// <param name="ptAccessor">Point accessor to get the actual point information.</param>
        public void WriteMeta(PtOctree<TPoint> octree, PointAccessor<TPoint> ptAccessor)
        {
            var rootCenter = octree.Root.Center;
            var rootSize = octree.Root.Size;

            var ptOctant = (PtOctantWrite<TPoint>)octree.Root;

            var spacing = ptOctant.Resolution;

            var jsonObj = new JObject(
                //new JProperty("numberOfPoints", octree.PointCount),
                //new JProperty("boundingBox",
                //    new JObject(
                //        new JProperty("center", new JArray(center.X, center.Y, center.Z)),
                //        new JProperty("size", new JArray(length.X, length.Y, length.Z))
                //    )
                //),

                new JProperty("octree",
                    new JObject(
                        new JProperty("maxLevel", octree.MaxLevel),
                        new JProperty("maxNoOfPointsInBucket", octree.MaxNoOfPointsInBucket),
                        new JProperty("spacingFactor", spacing),
                        new JProperty("rootNode",
                            new JObject(
                                new JProperty("center", new JArray(rootCenter.x, rootCenter.y, rootCenter.z)),
                                new JProperty("size", rootSize)
                            )
                        )
                    )
                )
            );

            //Add JProperty for "pointType" that contains all bools from the point accessor that are set to true.
            var ptTypeObj = new JObject();
            foreach (var propertyName in ptAccessor.GetPointType())
            {
                ptTypeObj.Add(propertyName, true);
            }
            var ptType = new JProperty("pointType", ptTypeObj);
            jsonObj.Add(ptType);

            //Write file
            using (StreamWriter file = File.CreateText(_fileFolderPath + "/meta.json"))
            {
                file.Write(jsonObj.ToString());
            }
        }

        /// <summary>
        /// Creates a binary encoded .node file. This file contains information about an octant and its payload.
        /// </summary>
        /// <param name="ptAccessor">Point accessor to get the actual point information.</param>
        /// <param name="node">The source octant.</param>
        public void WriteNode(PointAccessor<TPoint> ptAccessor, PtOctantWrite<TPoint> node)
        {
            var points = GetPointsFromGrid(node).ToList();

            if (node.IsLeaf)
                points.AddRange(node.Payload);

            if (points.Count == 0)
                return;

            var stream = File.Open(GetPathToFile(node), FileMode.OpenOrCreate);

            var writer = new BinaryWriter(stream);

            // write point count
            writer.Write(points.Count);

            // write length of one point
            var firstPt = points[0];
            writer.Write(ptAccessor.GetRawPoint(ref firstPt).Length);

            foreach (var point in points)
            {
                var pt = point;
                var rawPt = ptAccessor.GetRawPoint(ref pt);
                writer.Write(rawPt);
            }
            stream.Dispose();
        }

        #region Write .node files

        private IEnumerable<TPoint> GetPointsFromGrid(PtOctantWrite<TPoint> node)
        {
            foreach (var cell in node.Grid.GridCells)
            {
                if (cell != null)
                    yield return cell.Occupant;
            }
        }

        private string GetPathToFile(PtOctantWrite<TPoint> node)
        {
            var directoryInfo = Directory.CreateDirectory(_fileFolderPath + "\\Octants");
            return directoryInfo.FullName + "\\" + GetFilename(node);
        }

        private string GetFilename(PtOctantWrite<TPoint> node)
        {
            var fileName = node.Guid.ToString("N");

            fileName += ".node";
            return fileName;
        }

        #endregion
    }
}
