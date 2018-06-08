using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3.Images
{
    public class ImageSerializator : IImageSerializator
    {
        public Image Deserialize(string path)
        {
            var formatter = new XmlSerializer(typeof(Image));
            Image res;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                res = (Image)formatter.Deserialize(fs);
            }

            return res;
        }

        public void Serialize(string path, Image image)
        {
            var formatter = new XmlSerializer(typeof(Image));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, image);
            }
        }
    }
}
