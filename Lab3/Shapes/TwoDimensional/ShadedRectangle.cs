using System;

namespace Lab3.Shapes.TwoDimensional
{
    public class ShadedRectangle : Rectangle
    {
        public ShadedRectangle(float length, float width) 
        : base(length, width)
        {
            IsShaded = true;
        }

        public ShadedRectangle(float x, float y, float length, float width) 
        : base(x, y, length, width)
        {
            IsShaded = true;
        }
        
    }
}
