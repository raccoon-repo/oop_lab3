using System.Collections.Generic;

namespace Lab3.Vertices
{
    public class VertexConnections
    {
        private Vertex[] _vertices;

        /**
         * Key - number of vertex
         * Value - array of connected vertecies
         */
        private IDictionary<byte, byte[]> _connections;

        public Vertex[] Vertices { get; set; }
        public IDictionary<byte, byte[]> Connections { get; set; }

        public Vertex this[byte index]
        {
            get => _vertices[index]; 
            set => _vertices[index] = value; 
        }

        public byte[] GetConnections(byte vertexNumber)
        {
            if (_connections.TryGetValue(vertexNumber, out byte[] result))
                return result;
            return null;
        }
    }
}
