using Lab3.Drawers;
using Lab3.Shapes.ThreeDimensional;
using System;
using System.Windows.Forms;

namespace Lab3.View
{
    public partial class Form1 : Form
    {
        WinFormDrawer drawer;
        public Form1()
        {
            InitializeComponent();
            drawer = new WinFormDrawer() {
                Graphics = CreateGraphics()
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cube = new Cube(50, 50, 0, 50) { Drawer = drawer };
            var recpar = new RectangularParallelepiped(50, 50, 0, 50, 100, 75)
            { Drawer = drawer };

            recpar.Draw();

            //var g = CreateGraphics();
            //var p1 = new Point(5, 5);
            //var p2 = new Point(5, 30);
            //var pen = new Pen(Color.Red, 5);
            //g.DrawLine(pen, p1, p2);
            
        }
    }
}
