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
        public bool isStop { get; set; }
        public int currX { get; set; }
        public int currY { get; set; }
        public Color Color { get; set; }

        Color _color;
        CarType _type;
        double _beginx, _beginy, _stopx, _stopy, _endx, _endy, _turnx, _turny;
        bool _stop;
        const int _width = 800, _height = 800, _carwidth = 20, _carlength = 20, _speed = 10;

        public Car(Color color, CarType type)
        {
            Color = color;
            _color = color;
            _type = type;
            _stop = false;

            SetStartingPosition();
        }
        private void SetStartingPosition()
        {
            int padding = _carwidth / 2;
            switch (_type)
            {
                case CarType.xlxr:
                    _beginx = 0;
                    _beginy = _height * .55 + padding;
                    _stopx = _width * .3;
                    _stopy = 0;
                    _turnx = 0;
                    _turny = 0;
                    _endx = _width;
                    _endy = 0;
                    break;
                case CarType.xlyd:
                    _beginx = 0;
                    _beginy = _height * .6 + padding;
                    _stopx = _width * .3;
                    _stopy = 0;
                    _turnx = _width * .35 + padding;
                    _turny = 0;
                    _endx = _width;
                    _endy = _height;
                    break;

                case CarType.xlyu:
                    _beginx = 0;
                    _beginy = _height * .5 + padding;
                    _stopx = _width * .3;
                    _stopy = 0;
                    _turnx = _width * .5 + padding;
                    _turny = 0;
                    _endx = _width;
                    _endy = 0;
                    break;
                case CarType.xrxl:
                    _beginx = _width;
                    _beginy = _height * .40 + padding;
                    _stopx = _width * .7;
                    _stopy = 0;
                    _turnx = 0;
                    _turny = 0;
                    _endx = 0;
                    _endy = 0;
                    break;
                case CarType.xryd:
                    _beginx = _width;
                    _beginy = _height * .45 + padding;
                    _stopx = _width * .7;
                    _stopy = 0;
                    _turnx = _width * .45 + padding;
                    _turny = 0;
                    _endx = 0;
                    _endy = _height;
                    break;

                case CarType.xryu:
                    _beginx = _width;
                    _beginy = _height * .35 + padding;
                    _stopx = _width * .7;
                    _stopy = 0;
                    _turnx = _width * .60 + padding;
                    _turny = 0;
                    _endx = 0;
                    _endy = 0;
                    break;
                case CarType.ydyu:
                    _beginx = _height * .55 + padding;
                    _beginy = _height;
                    _stopx = 0;
                    _stopy = _height * .7;
                    _turnx = 0;
                    _turny = 0;
                    _endx = 0;
                    _endy = 0;
                    break;
                case CarType.ydxr:
                    _beginx = _height * .6 + padding;
                    _beginy = _height;
                    _stopx = 0;
                    _stopy = _height * .7;
                    _turnx = 0;
                    _turny = _height * .60 + padding;
                    _endx = _width;
                    _endy = 0;
                    break;

                case CarType.ydxl:
                    _beginx = _height * .5 + padding;
                    _beginy = _height;
                    _stopx = 0;
                    _stopy = _height * .7;
                    _turnx = 0;
                    _turny = _height * .45 + padding;
                    _endx = 0;
                    _endy = 0;
                    break;

                case CarType.yuyd:
                    _beginx = _height * .40 + padding;
                    _beginy = 0;
                    _stopx = 0;
                    _stopy = _height * .3;
                    _turnx = 0;
                    _turny = 0;
                    _endx = 0;
                    _endy = _height;
                    break;
                case CarType.yuxr:
                    _beginx = _height * .45 + padding;
                    _beginy = 0;
                    _stopx = 0;
                    _stopy = _height * .3;
                    _turnx = 0;
                    _turny = _height * .50 + padding;
                    _endx = _width;
                    _endy = 0;
                    break;

                case CarType.yuxl:
                    _beginx = _width * .35 + padding;
                    _beginy = 0;
                    _stopx = 0;
                    _stopy = _height * .3;
                    _turnx = 0;
                    _turny = _height * .35 + padding;
                    _endx = 0;
                    _endy = 0;
                    break;

                default:
                    break;
            }

            currX = (int)_beginx;
            currY = (int)_beginy;
        }
        public void Drive()
        {
            switch (_type)
            {
                case CarType.xlxr:
                case CarType.xlyd:
                case CarType.xlyu:
               
                    DriveXL();
                    break;
                case CarType.xrxl:
                case CarType.xryd:
                case CarType.xryu:
                    DriveXR();
                    break;
                case CarType.ydxl:
                case CarType.ydxr:
                case CarType.ydyu:
                    DriveY();
                    break;
                case CarType.yuyd:
                case CarType.yuxr:
                case CarType.yuxl:
                    DriveYU();
                    break;
            }
        }
        private void DriveXL()
        {
            int speed = _speed;

            if (currX < _stopx)
            {
                currX = currX + speed;
            }
            else if (_stop && currX == _stopx)
            {
                //System.Threading.Thread.Sleep(100);
                return;
            }
            else if (_turnx > 0)
            {
                if (currX < _turnx)
                {
                    currX = currX + speed;
                }
                else
                {
                    if (currY < _endy)
                    {
                        currY = currY + speed;
                    }
                    else if (currY > _endy)
                    {
                        currY = currY - speed;
                    }
                    else
                    {

                        SetStartingPosition();
                    }
                }

            }
            else if (currX < _endx)
            {
                currX = currX + speed;
            }
            else
            {
                SetStartingPosition();
            }


        }
        private void DriveXR()
        {
            int speed = _speed;

            if (currX > _stopx)
            {
                currX = currX - speed;
            }
            else if (_stop && currX == _stopx)
            {
                return;
                //System.Threading.Thread.Sleep(100);
            }
            else if (_turnx > 0)
            {
                if (currX > _turnx)
                {
                    currX = currX - speed;
                }
                else
                {
                    if (currY < _endy)
                    {
                        currY = currY + speed;
                    }
                    else if (currY > _endy)
                    {
                        currY = currY - speed;
                    }
                    else
                    {

                        SetStartingPosition();
                    }
                }

            }
            else if (currX > _endx)
            {
                currX = currX - speed;
            }
            else
            {
                SetStartingPosition();
            }


        }
        private void DriveY()
        {
            int speed = _speed;

            if (currY > _stopy)
            {
                currY = currY - speed;
            }
            else if (_stop && currY == _stopy)
            {
                return;
                //System.Threading.Thread.Sleep(100);
            }
            else if (_turny > 0)
            {
                if (currY > _turny)
                {
                    currY = currY - speed;
                }
                else
                {
                    if (currX < _endx)
                    {
                        currX = currX + speed;
                    }
                    else if (currX > _endx)
                    {
                        currX = currX - speed;
                    }
                    else
                    {

                        SetStartingPosition();
                    }
                }

            }
            else if (currY > _endy)
            {
                currY = currY - speed;
            }
            else
            {
                SetStartingPosition();
            }


        }
        private void DriveYU()
        {
            int speed = _speed;

            if (currY < _stopy)
            {
                currY = currY + speed;
            }
            else if (_stop && currY == _stopy)
            {
                return;
                //System.Threading.Thread.Sleep(100);
            }
            else if (_turny > 0)
            {
                if (currY < _turny)
                {
                    currY = currY + speed;
                }
                else
                {
                    if (currX < _endx)
                    {
                        currX = currX + speed;
                    }
                    else if (currX > _endx)
                    {
                        currX = currX - speed;
                    }
                    else
                    {

                        SetStartingPosition();
                    }
                }

            }
            else if (currY < _endy)
            {
                currY = currY + speed;
            }
            else
            {
                SetStartingPosition();
            }


        }
        public void Stop()
        {
            _stop = true;
            isStop = _stop;
        }
         public void Go()
        {
            _stop = false;
            isStop = _stop;
        }
        public void UpdateDisplay()
        {

        }
    }
}
