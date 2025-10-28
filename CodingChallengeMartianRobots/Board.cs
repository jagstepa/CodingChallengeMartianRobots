using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeMartianRobots
{
    internal class Board
    {
        public int _width;
        public int _height;
        private int currentRobotIndex = 1;
        private List<Robot> robots = new List<Robot>();

        public Board(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public string AddRobot(int x, int y, string orientation)
        {
            string robotName = "robot" + currentRobotIndex++;
            Board board = new Board(_width, _height);

            Robot robot = new Robot(board, robotName, x, y, orientation);
            robot.SetLostScents(robot.lostScents);
            robots.Add(robot);

            return robotName;
        }

        public string MoveRobot(string robotName, string movements)
        {
            Robot lostRobot = robots.FirstOrDefault(r => r.lostScents.Count > 0);
            bool isLostValue = lostRobot != null;

            Robot robot = robots.FirstOrDefault(p => p.Name == robotName);
            string output = robot.MoveAroundBoard(movements, isLostValue);

            //if (lostRobot != null)
            //{
            //    lostRobot.isLost = true;
            //}


            //if (robot.isLost || robot.lostScents != null)
            //{
            //    if (robot.lostScents is null)
            //    {
            //        robot.lostScents = new List<string>();

            //    }
            //    robot.lostScents.Add(robot._currentX.ToString() + robot._currentY);
            //}

            return output;
        }
    }
}
