using Lab3.Vertices;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.TwoDimensional
{
    public class Rectangle : AngularShape, ITwoDimensionalShape
    {

        private float _length;
        private float _width;

        public float Length
        {
            get => _length;
            set {
                if (value < 0)
                    return;

                Vertices.Vertices[1].Y = value;
                Vertices.Vertices[2].Y = value;
            }
        }
        public float Width
        {
            get => _width;
            set {
                if (value < 0)
                    return;
                Vertices.Vertices[2].X = value;
                Vertices.Vertices[3].X = value;
            }
        }

        /**
         * Alignment of verticies
         * 
         *  1_______2
         *  |       |
         *  |_______|
         *  0       3
         */

        public Rectangle(float length, float width)
        : this(0, 0, length, width) { }

        public Rectangle(float x, float y, float length, float width)
        {
            OffsetX = x;
            OffsetY = y;
            OffsetZ = 0;

            _length = length;
            _width = width;

            Vertices = new VertexConnections
            {
                Vertices = new Vertex[4]
                {
                    new Vertex { X = x, Y = y, Z = 0 },
                    new Vertex { X = x, Y = y + width, Z = 0 },
                    new Vertex { X = x + length, Y = y + width, Z = 0 },
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
            return _length * _width;
        }

        public override float Perimeter()
        {
            return (_length + _width) * 2.0f;
        }

        public override void Move(float x, float y, float z)
        {
            Vertices.Vertices[0].X = x;
            Vertices.Vertices[0].Y = y;

            Vertices.Vertices[1].X = x;
            Vertices.Vertices[1].Y = _width + y;

            Vertices.Vertices[2].X = _length + x;
            Vertices.Vertices[2].Y = _width + y;

            Vertices.Vertices[3].X = _length + x;
            Vertices.Vertices[3].Y = y;
        }

        public override void Scale(float fraction)
        {
            Length = _length * fraction;
            Width = _width * fraction;
        }


        public override string ToString()
        {
            return $"{{ \"shape\": \"rectangle\", \"width\": \"{_width}\", \"length\":\"{_length}\"}}";
        }
    }
}
