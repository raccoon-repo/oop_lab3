using Lab3.Drawers;
using Lab3.Shapes;
using System.Collections.Generic;

namespace Lab3
{
    public class Image
    {
        public IList<AngularShape> Shapes;

        public float X;
        public float Y;

        public void Move(float x, float y)
        {
            if (Shapes is null)
                return;

            foreach (var shape in Shapes)
            {
                if (shape is ITwoDimensionalShape)
                    shape.Move(shape.OffsetX + x, shape.OffsetY + y, shape.OffsetZ);
                if (shape is IThreeDimensionalShape)
                    shape.Move(0, shape.OffsetY +  x, shape.OffsetZ - y);
            }

            X = x;
            Y = y;
        }

        public void AddShape(AngularShape shape)
        {
            Shapes.Add(shape);
        }

        public void MoveShape(AngularShape shape, float x, float y)
        {
            shape.Move(shape.OffsetX + x, shape.OffsetY + y, shape.OffsetZ);
        }

    }
}
