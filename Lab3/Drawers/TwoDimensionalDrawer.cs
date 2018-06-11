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

            var verticesConnections = shape.Vertices;
            var vertices = verticesConnections.Vertices;
            var connections = verticesConnections.Connections;

            PointF p1, p2;
            Vertex v1, v2;

            for (byte i = 0; i < vertices.Count; i++)
            {
                // retrieve vertex
                v1 = vertices[i];

                // draw a line
                // to connect v1 with all other vertices
                foreach (var connection in connections[i])
                {
                    v2 = vertices[connection];
                    p1 = new PointF(v1.X, v1.Y);
                    p2 = new PointF(v2.X, v2.Y);

                    Graphics.DrawLine(Pen, p1, p2);
                }
            }
        }
    }
}
