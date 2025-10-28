using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeMartianRobots
{
    internal class Robot
    {
        const int rotateLeft = -90;
        const int rotateRight = 90;
        const int moveX = 50;
        const int moveY = -50;

        private Board _board;
        public int _currentX;
        public int _currentY;
        private int _currentRotate;
        public List<string> lostScents = new List<string>();
        public bool isLost = false;

        public string Name;
        public Robot(Board board, string name, int x = 0, int y = 0, string orientation = "N")
        {
            _board = board;
            Name = name;   
            _currentX = x;
            _currentY = y;
            _currentRotate = OrientationToDegrees(orientation);
        }

        private int OrientationToDegrees(string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return 0;
                case "E":
                    return 90;
                case "S": 
                    return 180;
                case "W": 
                    return 270;
                default:
                    throw new Exception("Invalid Orientation" + orientation);
            }
        }

        private string DegreesToOrientation(int degrees)
        {
            switch (degrees)
            {
                case 0:
                    return "N";
                case 90:
                    return "E";
                case 180:
                    return "S";
                case 270:
                    return "W";
                default:
                    throw new Exception("Invalid value" + degrees);
            }
        }

        public void SetLostScents(List<string> _lostScents)
        {
            lostScents = _lostScents;
        }

        public string MoveAroundBoard(string movements, bool isLostValue)
        {
            foreach (var move in movements)
            {
                int newX = _currentX;
                int newY = _currentY;

                switch (move)
                {
                    case 'L':
                        _currentRotate += rotateLeft;
                        break;
                    case 'R':
                        _currentRotate += rotateRight;
                        break;
                    case 'F':
                        switch (_currentRotate)
                        {
                            case 0:
                                newY += 1;
                                break;
                            case 90:
                                newX += 1;
                                break;
                            case 180:
                                newY -= 1;
                                break;
                            case 270:
                                newX -= 1;
                                break;
                        }
                        break;
                }

                if (newX < 0 || newX > _board._width || newY < 0 || newY > _board._height)
                {
                    if (!isLostValue)
                    {
                        isLost = true;
                        lostScents = new List<string>();
                        lostScents.Add(_currentX.ToString() + _currentY);
                        break;
                    }
                }
                else
                {
                    _currentX = newX;
                    _currentY = newY;
                }

                if (_currentRotate == 360)
                {
                    _currentRotate = 0;
                }
                else if (_currentRotate < 0) 
                {
                    _currentRotate += 360;
                }
            }

            return CurrentLocation();
        }

        private string CurrentLocation()
        {
            string location = _currentX + " " + _currentY + " " + DegreesToOrientation(_currentRotate);
            if (isLost)
            {
                location += " LOST";
                isLost = false;
            }

            return location;
        }
    }
}
