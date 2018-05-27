
using Lab3.Shapes;
using Lab3.Vertecies;
using System;
using System.Drawing;

namespace Lab3.Drawers
{
    public class ThreeDimensionalDrawer : IDrawer
    {
        public Graphics Graphics { get; set; }
        public Pen Pen { get; set; }

        private readonly float ALPHA;
        private readonly float COS_ALPHA;
        private readonly float SIN_ALPHA;
        private readonly Pen DEFAULT_PEN = new Pen(Color.Black);

        public ThreeDimensionalDrawer()
        {
            // Alpha is an angle between axis X and Y
            
            /*        
             *      Z ^
             *        |
             *        |
             *        |
             *        |
             *        +-----------> Y
             *       /_/  <-- alpha
             *      /
             *     / 
             *    X 
             */

            ALPHA = (float)((3 * Math.PI) / 4); //135*
            COS_ALPHA = (float)Math.Cos(ALPHA);
            SIN_ALPHA = (float)Math.Sin(ALPHA);
            Pen = DEFAULT_PEN;
        }

        public void Draw(AngularShape shape)
        {
            if (!(shape is IThreeDimensionalShape))
                return;

            var vertices = shape.Vertices.Vertices;
            var connections = shape.Vertices.Connections;

            Point p1, p2;
            Vertex v1, v2;

            for (byte i = 0; i < vertices.Length; i++)
            {
                v1 = vertices[i];

                foreach (var connection in connections[i])
                {
                    v2 = vertices[connection];

                    p1 = new Point((int)(v1.X * COS_ALPHA + v1.Y), (int)(v1.X * SIN_ALPHA - v1.Z));
                    p2 = new Point((int)(v2.X * COS_ALPHA + v2.Y), (int)(v2.X * SIN_ALPHA - v2.Z));

                    Graphics.DrawLine(Pen, p1, p2);
                }
            } 

        }
    }
}
