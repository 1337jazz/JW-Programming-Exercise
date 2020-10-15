using System.Collections.Generic;
using JW_Programming_Exercise.Library.Shared.Enums;
using JW_Programming_Exercise.Library.Shared.Interfaces;

namespace JW_Programming_Exercise.Library.Entities
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }
        public IEnumerable<Command> Commands { get; private set; }

        public Robot(IData data)
        {
            X = data.RobotStartX;
            Y = data.RobotStartY;
            Direction = data.InitialDirection;
            Commands = data.Commands;
        }

        public void Run()
        {
        }
    }
}