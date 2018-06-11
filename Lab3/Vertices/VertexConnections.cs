using System;
using System.Collections.Generic;

namespace Lab3.Vertices
{
    public class VertexConnections
    {

        /**
         * Key - number of vertex
         * Value - array of connected vertecies
         */
        public IDictionary<byte, List<byte>> Connections { get; set; }

        public IList<Vertex> Vertices { get; set; }

        public Vertex this[byte index]
        {
            get => Vertices[index]; 
            set => Vertices[index] = value; 
        }

        public List<byte> GetConnections(byte vertexNumber)
        {
            if (Connections.TryGetValue(vertexNumber, out var result))
                return result;
            return null;
        }
    }
}
