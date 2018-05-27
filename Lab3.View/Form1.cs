using Lab3.Drawers;
using Lab3.Shapes;
using Lab3.Shapes.ThreeDimensional;
using Lab3.Shapes.TwoDimensional;
using System;
using System.Windows.Forms;

namespace Lab3.View
{
    public partial class Form1 : Form
    {
        private TwoDimensionalDrawer twoDimensional;
        private ThreeDimensionalDrawer threeDimensional;
        AngularShape shape;

        public Form1()
        {
            InitializeComponent();
            twoDimensional = new TwoDimensionalDrawer() {
                Graphics = CreateGraphics()
            };

            threeDimensional = new ThreeDimensionalDrawer() {
                Graphics = CreateGraphics()
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shape = new Pyramid(60, 60, 100);
            threeDimensional.Draw(shape);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float x, y, z;
            float.TryParse(textBox1.Text, out x);
            float.TryParse(textBox2.Text, out y);
            float.TryParse(textBox3.Text, out z);

            shape.Move(x, y, z);
            threeDimensional.Graphics.Clear(System.Drawing.Color.White);
            threeDimensional.Draw(shape);

        }
    }
}
