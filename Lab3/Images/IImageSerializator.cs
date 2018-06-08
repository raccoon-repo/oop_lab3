using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Images
{
    public interface IImageSerializator
    {
        void Serialize(string path, Image image);
        Image Deserialize(string path);
    }
}
