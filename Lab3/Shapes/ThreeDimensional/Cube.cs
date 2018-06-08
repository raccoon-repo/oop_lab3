using Lab3.Vertices;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.ThreeDimensional
{
    [Serializable]
    public class Cube : AngularShape, IThreeDimensionalShape
    {
        private float _length;

        public float Length
        {
            get => _length;
            set {
                var vertecies = Vertices.Vertices;

                vertecies[1].X = value;
                vertecies[2].X = value; vertecies[2].Y = value;
                vertecies[3].Y = value;

                vertecies[4].Z = value;
                vertecies[5].X = value; vertecies[5].Z = value;
                vertecies[6].X = value; vertecies[6].Z = value;
                vertecies[6].Y = value;
                vertecies[7].Y = value; vertecies[7].Z = value; 
            }
        }

        /**
         *
         *     4+--------------+7       Z
         *     /:             /|        |
         *    / :            / |        |
         *  5+__:___________+6 |        |
         *   |  :           |  |        |
         *   | 0+-----------|--+3       +-----------Y
         *   | /            | /        /  
         *   |/             |/        / 
         *  1+______________+2       X
         *
         */

        public Cube(float x, float y, float z, float length)
        {
            _length = length;

            OffsetX = x;
            OffsetY = y;
            OffsetZ = z;
            Vertices = new VertexConnections
            {
                Connections = new Dictionary<byte, byte[]>(8)
                {
                    {0, new byte[] {1, 3, 4} }, {1, new byte[] {0, 2, 5} },
                    {2, new byte[] {1, 3, 6} }, {3, new byte[] {0, 2, 7} },
                    {4, new byte[] {0, 5, 7} }, {5, new byte[] {1, 4, 6} },
                    {6, new byte[] {2, 5, 7} }, {7, new byte[] {3, 4, 6} }
                },

                Vertices = new Vertex[8]
                {
         /* 0 */    new Vertex() {X = x, Y = y, Z = z},                    
         /* 1 */    new Vertex() {X = x + length, Y = y, Z = z},
         /* 2 */    new Vertex() {X = x + length, Y = y + length, Z = z},
         /* 3 */    new Vertex() {X = x, Y = y + length, Z = z},
         /* 4 */    new Vertex() {X = x, Y = y, Z = z + length},
         /* 5 */    new Vertex() {X = x + length, Y = y, Z = z + length},
         /* 6 */    new Vertex() {X = x + length, Y = y + length, Z = z + length},
         /* 7 */    new Vertex() {X = x, Y = y + length, Z = z + length},
                }
            };
        }

        public Cube() { }

        public Cube(float length)
        : this(0, 0, 0, length){ }

        public override float Area()
        {
            return (_length * _length) * 6;
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
            vertices[2].Y = y + _length;
            vertices[2].Z = z;

            vertices[3].X = x;
            vertices[3].Y = y + _length;
            vertices[3].Z = z;

            vertices[4].X = x;
            vertices[4].Y = y;
            vertices[4].Z = z + _length;

            vertices[5].X = x + _length;
            vertices[5].Y = y;
            vertices[5].Z = z + _length;

            vertices[6].X = x + _length;
            vertices[6].Y = y + _length;
            vertices[6].Z = z + _length;

            vertices[7].X = x;
            vertices[7].Y = y + _length;
            vertices[7].Z = z + _length;
        }

        public override float Perimeter()
        {
            return _length * 12;
        }

        public override void Scale(float fraction)
        {
            Length = _length * fraction;
        }

        public override string ToString()
        {
            return $"{{\"shape\": \"cube\", \"length\": \"{_length}\"}}";
        }
    }
}
