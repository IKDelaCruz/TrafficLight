using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLight
{
    public partial class Form1 : Form
    {
        int x, y;
        Car car1;
        public Form1()
        {
            InitializeComponent();
            car1 = new Car(Color.Red, CarType.xlxr);
           
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle ee = new Rectangle(car1.currX, car1.currY, 20, 20);
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
                
            }
        }

        private void tmrCar_Tick(object sender, EventArgs e)
        {
            car1.Drive();
            pbMain.Invalidate();
        }
    }
}
