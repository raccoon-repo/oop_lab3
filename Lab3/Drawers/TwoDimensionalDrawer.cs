using System.Drawing;
using Lab3.Shapes;
using Lab3.Vertices;

namespace Lab3.Drawers
{
    public class TwoDimensionalDrawer : IDrawer
    {
        public Graphics Graphics { get; set; }
        public Pen Pen { get; set; } 

        public TwoDimensionalDrawer()
        {
            Pen = new Pen(Color.Black, 2);
        }

        public void Draw(AngularShape shape)
        {
            if (!(shape is ITwoDimensionalShape))
                return;

            var verteciesConnections = shape.Vertices;
            var verticies = verteciesConnections.Vertices;
            var connections = verteciesConnections.Connections;

            Point p1, p2;
            Vertex v1, v2;

            for (byte i = 0; i < verticies.Length; i++)
            {
                // retrieve vertex
                v1 = verticies[i];

                // draw a line
                // to connect v1 with all other vertices
                foreach (var connection in connections[i])
                {
                    v2 = verticies[connection];
                    p1 = new Point((int)v1.X, (int)v1.Y);
                    p2 = new Point((int)v2.X, (int)v2.Y);

                    Graphics.DrawLine(Pen, p1, p2);
                }
            }
        }
    }
}
