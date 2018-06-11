using Lab3.Drawers;
using Lab3.Shapes;
using Lab3.Shapes.ThreeDimensional;
using Lab3.Shapes.TwoDimensional;
using System;
using Lab3.Images;
using System.Windows.Forms;
using Lab3.Images.Drawers;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Lab3.View
{
    public partial class Form1 : Form
    {
        private TwoDimensionalDrawer twoDimensional;
        private ThreeDimensionalDrawer threeDimensional;
        private ShadedRectangleDrawer shadedRectangleDrawer;
        private System.Drawing.Graphics graphics;
        private ImageDrawer imageDrawer;
        private Image image;
        private IImageSerializator imageSerializator;
        private static string projectDir = GetProjectDirectory();

        public Form1()
        {
            
            InitializeComponent();

            graphics = panel1.CreateGraphics();
            var pen = new System.Drawing.Pen(System.Drawing.Color.Black);

            twoDimensional = new TwoDimensionalDrawer() {
                Graphics = graphics, Pen = pen
            };

            threeDimensional = new ThreeDimensionalDrawer() {
                Graphics = graphics, Pen = pen
            };

            shadedRectangleDrawer = new ShadedRectangleDrawer() {
                Graphics = graphics, Pen = pen,
                TwoDimensionalDrawer = twoDimensional
            };

            imageDrawer = new ImageDrawer()
            {
                ThreeDimensionalDrawer = threeDimensional,
                TwoDimensionalDrawer = twoDimensional,
                ShadedRectangleDrawer = shadedRectangleDrawer
            };

            image = new Image(panel1.Height, panel1.Width);
            imageSerializator = new XmlImageSerializator();
        }


        private void Clear()
        {
            var pen = new System.Drawing.Pen(System.Drawing.Color.White);
            graphics.Clear(System.Drawing.Color.White);
        }

        private void DrawRectangle_Click(object sender, EventArgs e)
        {
            var widthS = RectangleW.Text;
            var lengthS = RectangleL.Text;
            var offsetXS = RectangleX.Text;
            var offsetYS = RectangleX.Text;
            float offsetX, offsetY;

            if (!float.TryParse(widthS, out var width))
                return;
            if (!float.TryParse(lengthS, out var length))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;

            image.AddShape(new Rectangle(offsetX, offsetY, length, width));
            Clear();
            imageDrawer.Draw(image);
        }

        private void DrawSquare_Click(object sender, EventArgs e)
        {
            var lengthS = SquareL.Text;
            var offsetYS = SquareY.Text;
            var offsetXS = SquareX.Text;
            float offsetX, offsetY;

            if (!float.TryParse(lengthS, out var length))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;

            image.AddShape(new Square(offsetX, offsetY, length));
            Clear();
            imageDrawer.Draw(image);
        }


        private void DrawCubeBtn_Click(object sender, EventArgs e)
        {
            var lengthS = CubeL.Text;
            var offsetXS = CubeX.Text;
            var offsetYS = CubeY.Text;
            var offsetZS = CubeZ.Text;
            float offsetX, offsetY, offsetZ;


            if (!float.TryParse(lengthS, out var length))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;
            if (!float.TryParse(offsetZS, out offsetZ))
                offsetZ = 0;

            image.AddShape(new Cube(offsetX, offsetY, offsetZ, length));
            Clear();
            imageDrawer.Draw(image);
        }

        private void DrawParal_Click(object sender, EventArgs e)
        {
            var widthS = ParalW.Text;
            var lengthS = ParalL.Text;
            var heightS = ParalH.Text;
            var offsetXS = ParalX.Text;
            var offsetYS = ParalY.Text;
            var offsetZS = ParalZ.Text;
            float offsetX, offsetY, offsetZ;

            if (!float.TryParse(widthS, out var width))
                return;
            if (!float.TryParse(lengthS, out var length))
                return;
            if (!float.TryParse(heightS, out var height))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;
            if (!float.TryParse(offsetZS, out offsetZ))
                offsetZ = 0;

            image.AddShape(new RectangularParallelepiped(offsetX, offsetY, offsetZ,
                                                         length, width, height));
            Clear();
            imageDrawer.Draw(image);
        }

        private void DrawPyramid_Click(object sender, EventArgs e)
        {
            var widthS = PyramidW.Text;
            var lengthS = PyramidL.Text;
            var heightS = PyramidH.Text;
            var offsetXS = PyramidX.Text;
            var offsetYS = PyramidY.Text;
            var offsetZS = PyramidZ.Text;
            float offsetX, offsetY, offsetZ;

            if (!float.TryParse(widthS, out var width))
                return;
            if (!float.TryParse(lengthS, out var length))
                return;
            if (!float.TryParse(heightS, out var height))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;
            if (!float.TryParse(offsetZS, out offsetZ))
                offsetZ = 0;

            image.AddShape(new Pyramid(offsetX, offsetY, offsetZ,
                                       width, length, height));
            Clear();
            imageDrawer.Draw(image);
        }

        private void DrawShadedRectangleBtn_Click(object sender, EventArgs e)
        {
            var widthS = ShRectangleW.Text;
            var lengthS = ShRectangleL.Text;
            var offsetXS = ShRectangleX.Text;
            var offsetYS = ShRectangleX.Text;
            float offsetX, offsetY;

            if (!float.TryParse(widthS, out var width))
                return;
            if (!float.TryParse(lengthS, out var length))
                return;

            if (!float.TryParse(offsetYS, out offsetY))
                offsetY = 0;
            if (!float.TryParse(offsetXS, out offsetX))
                offsetX = 0;

            image.AddShape(new ShadedRectangle(offsetX, offsetY, length, width));
            Clear();
            imageDrawer.Draw(image);
        }

        private void NewImgBtn_Click(object sender, EventArgs e)
        {
            image = new Image(panel1.Height, panel1.Width);
            Clear();
        }

        private void SaveImgBtn_Click(object sender, EventArgs e)
        {
            imageSerializator.Serialize($"{projectDir}\\out\\image.xml", image);
        }

        private void LoadLastBtn_Click(object sender, EventArgs e)
        {
            image = imageSerializator.Deserialize($"{projectDir}\\out\\image.xml");
            Clear();
            imageDrawer.Draw(image);
        }

        private static string GetProjectDirectory()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Regex regex = new Regex("\\\\bin\\\\Debug$");
            return regex.Replace(dir, "");
        }
    }
}
