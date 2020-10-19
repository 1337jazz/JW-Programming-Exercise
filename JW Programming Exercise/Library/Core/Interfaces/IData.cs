using System.Collections.Generic;
using JW_Programming_Exercise.Library.Core.Enums;

namespace JW_Programming_Exercise.Library.Core.Interfaces
{
    /// <summary>
    /// The interface for the data that will be fed into the Robot.
    /// These data points should be provided as a minimum.
    /// InputBase base class should implement this interface
    /// </summary>
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