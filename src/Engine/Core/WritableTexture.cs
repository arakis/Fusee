﻿using Fusee.Base.Common;
using Fusee.Engine.Common;
using Fusee.Serialization;
using System;

namespace Fusee.Engine.Core
{
    /// <summary>
    /// Special Texture, e.g. for usage in multipass rendering.
    /// </summary>
    public class WritableTexture : IWritableTexture
    {
        /// <summary>
        /// TextureChanged event notifies observing TextureManager about property changes and the Texture's disposal.
        /// </summary>
        public event EventHandler<TextureEventArgs> TextureChanged;

        /// <summary>
        /// SessionUniqueIdentifier is used to verify a Textures's uniqueness in the current session.
        /// </summary>
        public Suid SessionUniqueIdentifier { get; private set; }

        public RenderTargetTextureTypes TextureType { get; private set; }

        /// <summary>
        /// Width in pixels.
        /// </summary>
        public int Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Height in pixels.
        /// </summary>
        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// PixelFormat provides additional information about pixel encoding.
        /// </summary>
        public ImagePixelFormat PixelFormat
        {
            get;
            private set;
        }

        public bool DoGenerateMipMaps
        {
            get;
            private set;
        }

        public TextureWrapMode WrapMode
        {
            get;
            private set;
        }

        public TextureFilterMode FilterMode
        {
            get;
            private set;
        }


        /// <summary>
        /// Creates a new instance of type "WritableTexture".
        /// </summary>
        /// <param name="colorFormat">The color format of the texture, <see cref="ImagePixelFormat"/></param>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <param name="generateMipMaps">Defines if mipmaps are created.</param>
        /// <param name="filterMode">Defines the filter mode <see cref="TextureFilterMode"/>.</param>
        /// <param name="wrapMode">Defines the wrapping mode <see cref="TextureWrapMode"/>.</param>
        public WritableTexture(RenderTargetTextureTypes texType, ImagePixelFormat colorFormat, int width, int height, bool generateMipMaps = true, TextureFilterMode filterMode = TextureFilterMode.LINEAR, TextureWrapMode wrapMode = TextureWrapMode.REPEAT)
        {
            SessionUniqueIdentifier = Suid.GenerateSuid();
            PixelFormat = colorFormat;
            Width = width;
            Height = height;
            DoGenerateMipMaps = generateMipMaps;
            FilterMode = filterMode;
            WrapMode = wrapMode;
            TextureType = texType;
        }

        /// <summary>
        /// Create a texture that is intended to save position information.
        /// </summary>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <returns></returns>
        public static WritableTexture CreatePosTex(int width, int height)
        {
            return new WritableTexture(RenderTargetTextureTypes.G_POSITION, new ImagePixelFormat(ColorFormat.fRGB32), width, height, false, TextureFilterMode.NEAREST);
        }

        /// <summary>
        /// Create a texture that is intended to save albedo (rgb channels) and specular (alpha channel) information.
        /// </summary>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <returns></returns>
        public static WritableTexture CreateAlbedoSpecularTex(int width, int height)
        {
            return new WritableTexture(RenderTargetTextureTypes.G_ALBEDO_SPECULAR, new ImagePixelFormat(ColorFormat.RGBA), width, height, false);
        }

        /// <summary>
        /// Create a texture that is intended to save normal information.
        /// </summary>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <returns></returns>
        public static WritableTexture CreateNormalTex(int width, int height)
        {
            return new WritableTexture(RenderTargetTextureTypes.G_NORMAL, new ImagePixelFormat(ColorFormat.fRGB16), width, height, false, TextureFilterMode.NEAREST);
        }

        /// <summary>
        /// Create a texture that is intended to save depth information.
        /// </summary>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <returns></returns>
        public static WritableTexture CreateDepthTex(int width, int height)
        {
            return new WritableTexture(RenderTargetTextureTypes.G_DEPTH, new ImagePixelFormat(ColorFormat.Depth), width, height, false, TextureFilterMode.NEAREST, TextureWrapMode.CLAMP_TO_BORDER);
        }

        /// <summary>
        /// Create a texture that is intended to save ssao information.
        /// </summary>
        /// <param name="width">Width in px.</param>
        /// <param name="height">Height in px.</param>
        /// <returns></returns>
        public static WritableTexture CreateSSAOTex(int width, int height)
        {
            return new WritableTexture(RenderTargetTextureTypes.G_SSAO, new ImagePixelFormat(ColorFormat.fRGB32), width, height, false, TextureFilterMode.NEAREST);
        }

        /// <summary>
        /// Implementation of the <see cref="IDisposable"/> interface.
        /// </summary>
        public void Dispose()
        {
            TextureChanged?.Invoke(this, new TextureEventArgs(this, TextureChangedEnum.Disposed));
        }

        /// <summary>
        /// Destructor calls <see cref="Dispose"/> in order to fire TextureChanged event.
        /// </summary>
        ~WritableTexture()
        {
            Dispose();
        }
    }
}
