using Lab3.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Drawers
{
    public class ImageDrawer : IImageDrawer
    {
        public ThreeDimensionalDrawer ThreeDimensionalDrawer { get; set; }
        public TwoDimensionalDrawer TwoDimensionalDrawer { get; set; }
        public ShadedRectangleDrawer ShadedRectangleDrawer { get; set; }

        public void Draw(Image image)
        {
            foreach (var shape in image.Shapes)
            {
                if (shape is IThreeDimensionalShape)
                    ThreeDimensionalDrawer.Draw(shape);
                else if (shape is IShadedShape)
                    ShadedRectangleDrawer.Draw(shape);
                else if (shape is ITwoDimensionalShape)
                    TwoDimensionalDrawer.Draw(shape);
            }
        }
    }
}
