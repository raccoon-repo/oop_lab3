using Lab3.Vertices;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.TwoDimensional
{
    [Serializable]
    public class Square : AngularShape, ITwoDimensionalShape
    {
        private float _length;

        /**
         * Alignment of verticies
         * 
         *  1_______2
         *  |       |
         *  |_______|
         *  0       3
         */

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

        public Square() { }

        public Square(float length)
        : this (0, 0, length) { }

        public Square(float x, float y, float length)
        {

            OffsetX = x;
            OffsetY = y;
            OffsetZ = 0;
            _length = length;

            Vertices = new VertexConnections
            {
                Vertices = new Vertex[4]
                {
                    new Vertex { X = x, Y = y, Z = 0 },
                    new Vertex { X = x, Y = y + length, Z = 0 },
                    new Vertex { X = x + length, Y = y + length, Z = 0 },
                    new Vertex { X = x + length, Y = y, Z = 0 }
                },

                Connections = new Dictionary<byte, byte[]>(4)
                {
                    {0, new byte[] {1,3} }, {1, new byte[] {0, 2} },
                    {2, new byte[] {1,3} }, {3, new byte[] {0, 2}}
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
            Vertices.Vertices[1].Y = _length + y;

            Vertices.Vertices[2].X = _length + x;
            Vertices.Vertices[2].Y = _length + y;

            Vertices.Vertices[3].X = _length + x;
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

        public override string ToString()
        {
            return $"{{\"shape\":\"square\", \"length\":\"{_length}\"}}";
        }
    }
}
