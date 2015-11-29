/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

public class SplineLengthData : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SplineLengthData(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SplineLengthData obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static SplineLengthData Alloc() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.SplineLengthData_Alloc();
    SplineLengthData ret = (cPtr == global::System.IntPtr.Zero) ? null : new SplineLengthData(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_SplineLengthData bl) {
    C4dApiPINVOKE.SplineLengthData_Free(SWIGTYPE_p_p_SplineLengthData.getCPtr(bl));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Init(SplineObject op, int segment, ref Fusee.Math.double3 /* Vector*&_cstype */ padr) {
    bool ret = C4dApiPINVOKE.SplineLengthData_Init__SWIG_0(swigCPtr, SplineObject.getCPtr(op), segment, ref padr /* Vector*&_csin */);
    return ret;
  }

  public bool Init(SplineObject op, int segment) {
    bool ret = C4dApiPINVOKE.SplineLengthData_Init__SWIG_1(swigCPtr, SplineObject.getCPtr(op), segment);
    return ret;
  }

  public bool Init(SplineObject op) {
    bool ret = C4dApiPINVOKE.SplineLengthData_Init__SWIG_2(swigCPtr, SplineObject.getCPtr(op));
    return ret;
  }

  public double UniformToNatural(double t) {
    double ret = C4dApiPINVOKE.SplineLengthData_UniformToNatural(swigCPtr, t);
    return ret;
  }

  public double GetLength() {
    double ret = C4dApiPINVOKE.SplineLengthData_GetLength(swigCPtr);
    return ret;
  }

  public double GetSegmentLength(int a, int b) {
    double ret = C4dApiPINVOKE.SplineLengthData_GetSegmentLength(swigCPtr, a, b);
    return ret;
  }

}

}