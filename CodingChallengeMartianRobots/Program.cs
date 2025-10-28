using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeMartianRobots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "5 3", "1 1 E", "RFRFRFRF", "", "3 2 N", "FRRFLLFFRRFLL", "", "0 3 W", "LLFFFLFLFL" };

            var gridSize = lines[0].Split(' ');
            int gridWidth = Convert.ToInt16(gridSize[0]);
            int gridHeight = Convert.ToInt16(gridSize[1]);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Board board = new Board(gridWidth, gridHeight);

            int newRobotIndex = 0;
            string currentRobotName = "";
            List<string> robotOutput = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];

                if (line == "")
                {
                    newRobotIndex = i;
                }
                else if (i == newRobotIndex + 1)
                {
                    var robotPositon = line.Split(' ');
                    int robotX = Convert.ToInt16(robotPositon[0]);
                    int robotY = Convert.ToInt16(robotPositon[1]);
                    string robotOrientation = robotPositon[2];

                    currentRobotName = board.AddRobot(robotX, robotY, robotOrientation);
                }
                else if (i == newRobotIndex + 2)
                {
                    robotOutput.Add(board.MoveRobot(currentRobotName, line));
                }
            }

            Console.WriteLine("OUTPUT");
            Console.WriteLine(" ");
            Console.WriteLine(robotOutput[0]);
            Console.WriteLine(robotOutput[1]);
            Console.WriteLine(robotOutput[2]);
            Console.ReadKey();
        }
    }
}
