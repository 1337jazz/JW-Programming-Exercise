using System.Collections.Generic;
using JW_Programming_Exercise.Library.Core.Enums;

namespace JW_Programming_Exercise.Library.Core.Interfaces
{
    public interface IData
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RobotStartX { get; set; }
        public int RobotStartY { get; set; }
        public Direction InitialDirection { get; set; }
        public IEnumerable<Command> Commands { get; set; }
        public bool IsError { get; set; }
    }
}