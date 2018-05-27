﻿using Lab3.Shapes.TwoDimensional;
using Lab3.Vertecies;
using System;
using System.Collections.Generic;

namespace Lab3.Shapes.ThreeDimensional
{
    public class Pyramid : AngularShape, IThreeDimensionalShape
    {

        private float _height;
        private float _width;
        private float _length;

        public float Height
        {
            get => _height;
            set {
                if (value < 0)
                    return;
                Vertices.Vertices[4].Z = value;
            }
        }

        public float Width
        {
            get => _width;
            set {
                if (value < 0)
                    return;
                Vertices.Vertices[3].Y = value;
                Vertices.Vertices[2].Y = value;
            }
        }

        public float Length
        {
            get => _length;
            set {
                if (value < 0)
                    return;
                Vertices.Vertices[1].X = value;
                Vertices.Vertices[2].X = value;
            }
        }

        public Pyramid(float width, float length, float height)
        : this(0, 0, 0, width, length, height) { }

        public Pyramid(float x, float y, float z, float width, 
                       float length, float height)
        {
            if (width < 0 || length < 0 || height < 0)
                throw new ArgumentException("Length and width and height must pe positive number");

            _height = height;
            _length = length;
            _width = width;

            Vertices = new VertexConnections()
            {

                Vertices = new Vertex[5]
                {
                    new Vertex() {X = x, Y = y, Z = z},
                    new Vertex() {
                        X = x + length, 
                        Y = y,
                        Z = z
                    },

                    new Vertex() {
                        X = x + length,
                        Y = y + width,
                        Z = z
                    },

                    new Vertex() {
                        X = x,
                        Y = y + width,
                        Z = z
                    },

                    // top of the pyramid
                    new Vertex() {
                        X = (2*x + length) / 2,
                        Y = (2*y + width) / 2,
                        Z = z + height
                    }
                },

                Connections = new Dictionary<byte, byte[]>()
                {
                    {0, new byte[] {1, 3, 4} }, {1, new byte[] {0, 2, 4} },
                    {2, new byte[] {1, 3, 4} }, {3, new byte[] {0, 2, 4 }},
                    {4, new byte[] {0, 1, 2, 3}}
                }
            };
        }

        public override float Area()
        {
            throw new NotImplementedException();
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

            vertices[4].X = (2 * x + _length) / 2;
            vertices[4].Y = (2 * y + _width) / 2;
            vertices[4].Z = z + _height;

        }

        public override float Perimeter()
        {
            throw new NotImplementedException();
        }

        public override void Scale(float fraction)
        {
            throw new NotImplementedException();
        }
    }
}
