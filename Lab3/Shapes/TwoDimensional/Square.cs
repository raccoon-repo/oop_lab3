using Lab3.Vertecies;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.TwoDimensional
{
    public class Square : AngularShape
    {
        private float _length;

        public float Length
        {
            get => _length;
            set {

                if (value <= 0)
                    return;
                Vertices.Vertices[3].X = value;
                Vertices.Vertices[2].X = value;
                Vertices.Vertices[2].Y = value;
                Vertices.Vertices[1].Y = value;
            }
        }

        public Square(float length)
        : this (0, 0, length) { }

        public Square(float x, float y, float length)
        {
            _length = length;

            Vertices = new VertexConnections
            {
                Vertices = new Vertex[4]
                {
                    new Vertex { X = x, Y = y, Z = 0 },
                    new Vertex { X = x, Y = y + length, Z = 0 },
                    new Vertex { X = x + length, Y = y + length, Z = 0 },
                    new Vertex { X = x + length, Y = y + length, Z = 0 }
                },

                Connections = new Dictionary<byte, byte[]>(4)
                {
                    {0, new byte[] {1,3} }, {1, new byte[] {0, 2} },
                    {2, new byte[] {1,3} }, {3, new byte[] {1, 2}}
                }
            };
        }

        public override float Area()
        {
            return _length * 2;
        }

        public override void Move(float x, float y, float z)
        {
            Vertices.Vertices[0].X = x;
            Vertices.Vertices[0].Y = y;

            Vertices.Vertices[1].X = x;
            Vertices.Vertices[1].Y = Vertices.Vertices[1].Y + y;

            Vertices.Vertices[2].X = Vertices.Vertices[2].X + x;
            Vertices.Vertices[2].Y = Vertices.Vertices[2].Y + y;

            Vertices.Vertices[3].X = Vertices.Vertices[3].X + x;
            Vertices.Vertices[3].Y = y;
        }

        public override float Perimeter()
        {
            return _length * 4;
        }

        public override void Scale(float fraction)
        {
            Length = _length * fraction;
        }
    }
}
