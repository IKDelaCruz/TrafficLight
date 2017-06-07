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
        int _step = 1;

        List<Car> cars = new List<Car>();
        public Form1()
        {
            InitializeComponent();

            cars.Add(new Car(Color.Blue, CarType.xlyu));
            cars.Add(new Car(Color.Blue, CarType.xlxr));
            cars.Add(new Car(Color.Blue, CarType.xlyd));

            cars.Add(new Car(Color.Blue, CarType.ydxl));
            cars.Add(new Car(Color.Blue, CarType.ydyu));
            cars.Add(new Car(Color.Blue, CarType.ydxr));

            cars.Add(new Car(Color.Blue, CarType.xryd));
            cars.Add(new Car(Color.Blue, CarType.xrxl));
            cars.Add(new Car(Color.Blue, CarType.xryu));

            cars.Add(new Car(Color.Blue, CarType.yuxr));
            cars.Add(new Car(Color.Blue, CarType.yuyd));
            cars.Add(new Car(Color.Blue, CarType.yuxl));

           
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {

            foreach (Car c in cars)
            {
                Rectangle cr = new Rectangle(c.currX, c.currY, 20, 20);
                using (Pen pen = new Pen(c.Color, 5))
                {
                    SolidBrush blueBrush = new SolidBrush(c.isStop ? Color.Red : Color.Green);
                    e.Graphics.DrawRectangle(pen, cr);
                    e.Graphics.FillRectangle(blueBrush, cr);
                }
            }


        }

        private void tmrStopLight_Tick(object sender, EventArgs e)
        {
            ToggleStopLight();
        }
        private void ToggleStopLight()
        {
           
            switch (_step)
            {
                case 1:
                    cars[0].Go();
                    cars[1].Go();
                    cars[3].Stop();
                    cars[4].Stop();
                    cars[6].Stop();
                    cars[7].Stop();
                    cars[9].Stop();
                    cars[10].Stop();
                    break;
                case 2:
                    cars[0].Stop();
                    cars[1].Stop();
                    cars[3].Go();
                    cars[4].Go();
                    cars[6].Stop();
                    cars[7].Stop();
                    cars[9].Stop();
                    cars[10].Stop();
                    break;
                case 3:
                    cars[0].Stop();
                    cars[1].Stop();
                    cars[3].Stop();
                    cars[4].Stop();
                    cars[6].Go();
                    cars[7].Go();
                    cars[9].Stop();
                    cars[10].Stop();
                    break;
                case 4:
                    cars[0].Stop();
                    cars[1].Stop();
                    cars[3].Stop();
                    cars[4].Stop();
                    cars[6].Stop();
                    cars[7].Stop();
                    cars[9].Go();
                    cars[10].Go();
                    break;
            }
            if (_step < 4)
                _step++;
            else
                _step = 1;
        }
        private void tmrCar_Tick(object sender, EventArgs e)
        {
            //bgDrive.RunWorkerAsync();
            //tmrCar.Enabled = false;
            foreach (Car c in cars)
            {
                c.Drive();
            }
            pbMain.Invalidate();
        }

        private void bgDrive_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Car c in cars)
                {
                    c.Drive();
                }
                pbMain.Invalidate();

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToggleStopLight();
        }
    }
}
