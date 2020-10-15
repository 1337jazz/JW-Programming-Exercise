using System.Collections.Generic;
using JW_Programming_Exercise.Library.Shared.Enums;
using JW_Programming_Exercise.Library.Shared.Interfaces;

namespace JW_Programming_Exercise.Library.Data
{
    public abstract class InputBase : IData
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RobotStartX { get; set; }
        public int RobotStartY { get; set; }
        public Direction InitialDirection { get; set; }
        public IEnumerable<Command> Commands { get; set; }

        public InputBase()
        {
            Read();
        }

        public abstract void Read();
    }
}