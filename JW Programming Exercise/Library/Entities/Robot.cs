using System;
using System.Collections.Generic;
using JW_Programming_Exercise.Library.Core.Enums;
using JW_Programming_Exercise.Library.Core.Interfaces;

namespace JW_Programming_Exercise.Library.Entities
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public IEnumerable<Command> Commands { get; private set; }
        public int LimitX { get; private set; }
        public int LimitY { get; private set; }
        public string Result { get; private set; }
        public bool DataError { get; set; }

        public Robot(IData data)
        {
            X = data.RobotStartX;
            Y = data.RobotStartY;
            CurrentDirection = data.InitialDirection;
            Commands = data.Commands;
            LimitX = data.RoomWidth;
            LimitY = data.RoomHeight;
            DataError = data.IsError;
        }

        /// <summary>
        /// The main command to run the Robot and determine the result
        /// </summary>
        public void Run()
        {
            if (!DataError)
            {
                ExecuteCommands();
                var direction = (Enum.GetName(typeof(Direction), CurrentDirection)).Substring(0, 1);
                Result = $"{X} {Y} {direction}";
            }
            else
            {
                Result = "Invalid data";
            }
        }

        /// <summary>
        /// Execute each command in the command list.
        /// </summary>
        private void ExecuteCommands()
        {
            foreach (var command in Commands)
            {
                switch (command)
                {
                    case Command.TurnLeft:
                        CurrentDirection = CurrentDirection == Direction.North ? Direction.West : CurrentDirection -= 1;
                        break;

                    case Command.TurnRight:
                        CurrentDirection = CurrentDirection == Direction.West ? Direction.North : CurrentDirection += 1;
                        break;

                    case Command.WalkForward: Move(); break;

                    default: break;
                }
            }
        }

        /// <summary>
        /// Moves forward in the current direction if the Robot will not pass into a wall in the room
        /// </summary>
        private void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.North: Y = Y - 1 < 0 ? Y : Y -= 1; break;
                case Direction.East: X = X + 1 > LimitX ? X : X += 1; break;
                case Direction.South: Y = Y + 1 > LimitY ? Y : Y += 1; break;
                case Direction.West: X = X - 1 < 0 ? X : X -= 1; break;
                default: break;
            }
        }
    }
}