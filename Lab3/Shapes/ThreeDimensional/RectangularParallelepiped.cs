
using Lab3.Vertices;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.ThreeDimensional
{
    [Serializable]
    public class RectangularParallelepiped : AngularShape, IThreeDimensionalShape
    {
        private float _width;
        private float _height;
        private float _length;

        public float Width
        {
            get => _width;
            set {
                var vertices = Vertices.Vertices;

                vertices[2].Y = value;
                vertices[3].Y = value;
                vertices[6].Y = value;
                vertices[7].Y = value;
            }
        }

        public float Height
        {
            get => _height;
            set {
                var vertices = Vertices.Vertices;

                vertices[4].Z = value;
                vertices[5].Z = value;
                vertices[6].Z = value;
                vertices[7].Z = value;
            }
        }

        public float Length
        {
            get => _length;
            set {
                var vertices = Vertices.Vertices;

                vertices[0].X = value;
                vertices[2].X = value;
                vertices[4].X = value;
                vertices[6].X = value;
            }
        }

        public RectangularParallelepiped() { }

        public RectangularParallelepiped(float x, float y, float z, 
                                         float length, float width, 
                                         float height)
        {
            OffsetX = x;
            OffsetY = y;
            OffsetZ = z;

            _height = height;
            _length = length;
            _width = width;

            Vertices = new VertexConnections
            {
                Connections = new Dictionary<byte, List<byte>>(8)
                {
                    {0, new List<byte>() {1, 3, 4} }, {1, new List<byte>() {0, 2, 5} },
                    {2, new List<byte>() {1, 3, 6} }, {3, new List<byte>() {0, 2, 7} },
                    {4, new List<byte>() {0, 5, 7} }, {5, new List<byte>() {1, 4, 6} },
                    {6, new List<byte>() {2, 5, 7} }, {7, new List<byte>() {3, 4, 6} }
                },

                Vertices = new Vertex[8]
                {
         /* 0 */    new Vertex() {X = x, Y = y, Z = z},                    
         /* 1 */    new Vertex() {X = x + length, Y = y, Z = z},
         /* 2 */    new Vertex() {X = x + length, Y = y + width, Z = z},
         /* 3 */    new Vertex() {X = x, Y = y + width, Z = z},
         /* 4 */    new Vertex() {X = x, Y = y, Z = z + height},
         /* 5 */    new Vertex() {X = x + length, Y = y, Z = z + height},
         /* 6 */    new Vertex() {X = x + length, Y = y + width, Z = z + height},
         /* 7 */    new Vertex() {X = x, Y = y + width, Z = z + height},
                }
            };
        }

        public RectangularParallelepiped(float length, float width, float height)
        : this(0, 0, 0, length, width, height) { }

        public override float Area()
        {
            return ((_width * _length) * 2) + ((_width + _length) * 2 * _height);
        }

        public override float Perimeter()
        {
            return _height * 4 + (_width + _length) * 4;  
        }

        public override void Move(float x, float y, float z)
        {
            var vertices = Vertices.Vertices;

            vertices[0].X = x;
            vertices[0].Y = y;
            vertices[0].Z = z;

            vertices[1].X = x + _length;
            vertices[1].Y = y;
            vertices[1].Z = z;

            vertices[2].X = x + _length;
            vertices[2].Y = y + _width;
            vertices[2].Z = z;

            vertices[3].X = x;
            vertices[3].Y = y + _width;
            vertices[3].Z = z;

            vertices[4].X = x;
            vertices[4].Y = y;
            vertices[4].Z = z  + _height;

            vertices[5].X = x + _length;
            vertices[5].Y = y;
            vertices[5].Z = z + _height;

            vertices[6].X = x + _length;
            vertices[6].Y = y + _width;
            vertices[6].Z = z + _height;

            vertices[7].X = x;
            vertices[7].Y = y + _width;
            vertices[7].Z = z + _height;
        }

        public override void Scale(float fraction)
        {
            Height = _height * fraction;
            Width = _width * fraction;
            Length = _length * fraction;
        }

        public override string ToString()
        {
            return $"{{\"shape\": \"rectangular paralellepiped\", \"width\": \"{_width}\", " +
                $"\"height\": \"{_height}\", \"length\": \"{_length}\"}}";
        }
    }
}
