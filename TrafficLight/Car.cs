using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficLight
{
    public enum CarType
    {
        xlxr = 0,
        xlyd,
        xlyu,

        xrxl,
        xryd,
        xryu,


        yuyd,
        yuxl,
        yuxr,

        ydyu,
        ydxl,
        ydxr

    }


    public class Car
    {
        public int currX { get; set; }
        public int currY { get; set; }

        const int maxx = 800, maxy = 800, minx = 0, miny = 0;
        int intersection = 260;
        int beginx = 0; int endx = 0;
        int xloc, yloc;
        int step = 10;

        CarType _cartype;
        bool _stop = false;
        public Car(Color col, CarType type)
        {
           
            _cartype = type;

            if (type == CarType.xlxr)
            {
                beginx = minx;
                endx = maxx;
                xloc = beginx;
                yloc = 450;
            }
        }
        public void Drive()
        {

            //drive until stoplight
            if (xloc < intersection)
            {
                xloc = xloc + 10;
                UpdateDisplay();
            }
            //check if go
            else if (_stop)
            {
                System.Threading.Thread.Sleep(100);
            }

            else if (xloc < endx)
            {
                xloc = xloc + 10;
                UpdateDisplay();
            }


        }
        public void Stop()
        {
            _stop = false;
        }
        public void UpdateDisplay()
        {
            currX = xloc;
            currY = yloc;
           // System.Threading.Thread.Sleep(500);
        }
    }
}
