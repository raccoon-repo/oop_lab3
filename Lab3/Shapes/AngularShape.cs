using Lab3.Drawers;
using Lab3.Vertices;
using System;
using System.Xml.Serialization;

namespace Lab3.Shapes
{
    public abstract class AngularShape
    {

        public IDrawer Drawer { get; set; }
        private VertexConnections vertices = new VertexConnections();
        public bool IsShaded { get; set; }
        public VertexConnections Vertices
        {
            get => vertices;
            set => vertices = value;
        }
        
        public void Draw()
        {
            Drawer.Draw(this);
        }

        public float OffsetX { get; protected set; }
        public float OffsetY { get; protected set; }
        public float OffsetZ { get; protected set; }

        public abstract float Area();
        public abstract float Perimeter();
        public abstract void Move(float x, float y, float z);
        public abstract void Scale(float fraction);
        public override string ToString() { return "Base Shape Object"; }
    }
}
