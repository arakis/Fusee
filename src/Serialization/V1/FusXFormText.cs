﻿
namespace Fusee.Serialization.V1
{
    /// <summary>
    /// Defines the alignment in y direction.
    /// </summary>
    public enum FusVerticalTextAlignment
    {
        /// <summary>
        /// The text will be aligned to the top border of the enclosing MinMaxRect.
        /// </summary>
        TOP,

        /// <summary>
        /// The text will be aligned to the middle of vertical axis of the enclosing MinMaxRect.
        /// </summary>
        CENTER,

        /// <summary>
        /// The text will be aligned to the bottom border of the enclosing MinMaxRect.
        /// </summary>
        BOTTOM
    }

    /// <summary>
    /// Defines the alignment in y direction.
    /// </summary>
    public enum FusHorizontalTextAlignment
    {
        /// <summary>
        /// The text will be aligned to the left border of the enclosing MinMaxRect.
        /// </summary>
        LEFT,

        /// <summary>
        /// The text will be aligned to the center of vertical axis of the enclosing MinMaxRect.
        /// </summary>
        CENTER,

        /// <summary>
        /// The text will be aligned to right border of the enclosing MinMaxRect.
        /// </summary>
        RIGHT
    }

    /// <summary>
    /// Enables the scene renderer to treat GUI text differently.
    /// </summary>

    public class FusXFormText : FusComponent
    {
        /// <summary>
        /// The width of the text.
        /// </summary>
        public float Width;

        /// <summary>
        /// The height of the text.
        /// </summary>
        public float Height;

        /// <summary>
        /// The <see cref="FusHorizontalTextAlignment"/>.
        /// </summary>
        public FusHorizontalTextAlignment HorizontalAlignment;

        /// <summary>
        /// The <see cref="FusVerticalTextAlignment"/>.
        /// </summary>
        public FusVerticalTextAlignment VerticalAlignment;
    }

}
