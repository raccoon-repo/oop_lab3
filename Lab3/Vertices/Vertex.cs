﻿using System;


namespace Lab3.Vertices
{
    [Serializable]
    public struct Vertex
    {
        public float X;
        public float Y;
        public float Z;

        public override string ToString()
        {
            return "X = " + X + " Y = " + Y + " Z = " + Z;
        }
    }
}
