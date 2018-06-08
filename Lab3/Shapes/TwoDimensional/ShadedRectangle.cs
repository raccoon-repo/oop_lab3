using System;

namespace Lab3.Shapes.TwoDimensional
{
    [Serializable]
    public class ShadedRectangle : Rectangle, ITwoDimensionalShape, IShadedShape
    {
        public ShadedRectangle() { }

        public ShadedRectangle(float length, float width) 
        : base(length, width) {}

        public ShadedRectangle(float x, float y, float z, float length, float width) 
        : base(x, y, length, width) { }
        
    }
}
