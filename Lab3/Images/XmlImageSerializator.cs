using Lab3.Shapes;
using Lab3.Vertices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab3.Images
{
    public class XmlImageSerializator : IImageSerializator
    {
        public Image Deserialize(string path)
        {
            

            var xDoc = new XmlDocument();
            xDoc.Load(path);
            var root = xDoc.DocumentElement;
            var width = float.Parse(root.GetAttribute("width"));
            var height = float.Parse(root.GetAttribute("height"));
            var image = new Image(height, width);

            foreach (XmlElement child in root.ChildNodes[0].ChildNodes)
            {
                var fullTypeName = child.GetAttribute("type");
                var type = Type.GetType(fullTypeName, true, false);
                AngularShape shape = (AngularShape) Activator.CreateInstance(type);

                var vertexConnections = new VertexConnections()
                {
                    Vertices = new List<Vertex>(),
                    Connections = new Dictionary<byte, List<byte>>()
                };

                shape.Vertices = vertexConnections;

                foreach (XmlElement vertexNode in child.FirstChild.ChildNodes)
                {
                    var vertex = new Vertex {
                        X = float.Parse(vertexNode.GetAttribute("X")),
                        Y = float.Parse(vertexNode.GetAttribute("Y")),
                        Z = float.Parse(vertexNode.GetAttribute("Z"))
                    };

                    shape.Vertices.Vertices.Add(vertex);
                }

                foreach (XmlElement connectionNode in child.LastChild.ChildNodes)
                {
                    var vNum = byte.Parse(connectionNode.GetAttribute("vertex"));
                    var bytesList = new List<byte>();

                    var text = connectionNode.FirstChild.Value;
                    text = text.Replace("[", "").Replace("]", "");
                    var bytes = text.Split(',');

                    foreach (var b in bytes)
                    {
                        bytesList.Add(byte.Parse(b));
                    }

                    shape.Vertices.Connections.Add(vNum, bytesList);
                }

                image.AddShape(shape);
            }

            return image;

        }

        public void Serialize(string path, Image image)
        {
            var xDoc = new XmlDocument();
            xDoc.AppendChild(xDoc.CreateElement("image"));
            var root = xDoc.DocumentElement;
            root.SetAttribute("width", image.Width.ToString());
            root.SetAttribute("height", image.Length.ToString());

            var shapes = xDoc.CreateElement("shapes");
            root.AppendChild(shapes);

            foreach (var shape in image.Shapes)
            {
                var shapeNode = xDoc.CreateElement("shape");
                shapeNode.SetAttribute("type", shape.GetType().FullName);


                var connections = shape.Vertices;
                var vertices = connections.Vertices;
                var verticesConnections = connections.Connections;

                var verticesNode = xDoc.CreateElement("vertices");

                foreach(var vertex in vertices)
                {
                    var vertexNode = xDoc.CreateElement("vertex");
                    vertexNode.SetAttribute("X", vertex.X.ToString());
                    vertexNode.SetAttribute("Y", vertex.Y.ToString());
                    vertexNode.SetAttribute("Z", vertex.Z.ToString());
                    verticesNode.AppendChild(vertexNode);
                }


                var connectionsNode = xDoc.CreateElement("connections");

                foreach (var pair in verticesConnections)
                {
                    var connectionNode = xDoc.CreateElement("connection");
                    var vertexAttr = xDoc.CreateAttribute("vertex");
                    vertexAttr.Value = pair.Key.ToString();
                    connectionNode.Attributes.Append(vertexAttr);

                    var connectionsString = new StringBuilder();
                    connectionsString.Append("[");

                    for (int i = 0; i < pair.Value.Count; i++)
                    {
                        if (i < pair.Value.Count - 1)
                            connectionsString.Append(pair.Value[i] + ",");
                        else if (i == pair.Value.Count - 1)
                            connectionsString.Append(pair.Value[i]);
                    }
                    connectionsString.Append("]");
                    connectionNode.AppendChild(xDoc.CreateTextNode(connectionsString.ToString()));

                    connectionsNode.AppendChild(connectionNode);
                }

                
                shapeNode.AppendChild(verticesNode);
                shapeNode.AppendChild(connectionsNode);
                shapes.AppendChild(shapeNode);
            }

            root.AppendChild(shapes);
            xDoc.Save(path);
        }
    }
}
