using Lab3.Shapes;
using Lab3.Shapes.TwoDimensional;
using System.Drawing;

namespace Lab3.Drawers
{
    public class ShadedRectangleDrawer : IDrawer
    {
        public Graphics Graphics { get; set; }
        public Pen Pen { get; set; }
        public IDrawer TwoDimensionalDrawer { get; set; }

        public void Draw(AngularShape shape)
        {
            if (!(shape is ShadedRectangle rectangle))
                return;

            float xMin = rectangle.Vertices.Vertices[0].X;
            float yMin = rectangle.Vertices.Vertices[0].Y;

            float xMax = rectangle.Vertices.Vertices[2].X;
            float yMax = rectangle.Vertices.Vertices[2].Y;

            Point p1, p2;

            for (int i = (int)xMin; i < xMax; i += 4)
            {
                p1 = new Point(i, (int)yMin);
                p2 = new Point(i, (int)yMax);

                Graphics.DrawLine(Pen, p1, p2);
            }

            for (int j = (int)yMin; j < yMax; j += 4)
            {
                p1 = new Point((int)xMin, j);
                p2 = new Point((int)xMax, j);

                Graphics.DrawLine(Pen, p1, p2);
            }

            TwoDimensionalDrawer.Draw(shape);
        } 
    }
}
