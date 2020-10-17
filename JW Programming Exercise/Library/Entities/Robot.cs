using JW_Programming_Exercise.Library.Shared.Enums;
using JW_Programming_Exercise.Library.Shared.Interfaces;

namespace JW_Programming_Exercise.Library.Entities
{
    public class Robot : CommandableBase
    {
        public Robot(IData data)
        {
            X = data.RobotStartX;
            Y = data.RobotStartY;
            Direction = data.InitialDirection;
            Commands = data.Commands;
        }

        protected override void ExecuteCommands()
        {
            foreach (var command in Commands)
            {
                switch (command)
                {
                    case Command.TurnLeft:
                        Direction = Direction == Direction.North ? Direction.West : Direction -= 1;
                        break;

                    case Command.TurnRight:
                        Direction = Direction == Direction.West ? Direction.North : Direction += 1;
                        break;

                    case Command.WalkForward:
                        Move();
                        break;

                    default: break;
                }
            }
        }

        private void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    Y--;
                    break;

                case Direction.East:
                    X++;
                    break;

                case Direction.South:
                    Y++;
                    break;

                case Direction.West:
                    X--;
                    break;

                default:
                    break;
            }
        }
    }
}