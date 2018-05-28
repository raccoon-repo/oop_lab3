using Lab3.Drawers;
using Lab3.Shapes;
using Lab3.Shapes.ThreeDimensional;
using Lab3.Shapes.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab3.View
{
    public partial class Form1 : Form
    {
        private TwoDimensionalDrawer twoDimensional;
        private ThreeDimensionalDrawer threeDimensional;
        private ShadedRectangleDrawer shadedRectangleDrawer;
        private System.Drawing.Graphics graphics;
        private ImageDrawer imageDrawer;
        AngularShape shape;

        public Form1()
        {
            
            InitializeComponent();

            graphics = CreateGraphics();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            float x, y, z;
            var xParse = float.TryParse(textBox1.Text, out x);
            var yParse = float.TryParse(textBox2.Text, out y);
            var zParse = float.TryParse(textBox3.Text, out z);

            var pyramid = new Pyramid(10, 200, -120, 100, 75, 75);
            var cube = new Cube(0, 50, -200, 50);
            var shadedRectangle = new ShadedRectangle(150, 100);
            var paralellepiped = new RectangularParallelepiped(0, 400, -120, 100, 200, 50);


            var image = new Image()
            {
                Shapes = new List<AngularShape>()
                {
                    pyramid, cube, shadedRectangle, paralellepiped
                }
            };

            if (xParse && yParse)
            {
                image.Move(x, y);
            }
            imageDrawer.Draw(image);
        }

        private void Clear()
        {
            var pen = new System.Drawing.Pen(System.Drawing.Color.White);
            graphics.Clear(System.Drawing.Color.White);
        }
    }
}
