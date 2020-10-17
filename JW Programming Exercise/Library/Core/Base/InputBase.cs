using System.Collections.Generic;
using JW_Programming_Exercise.Library.Core.Enums;
using JW_Programming_Exercise.Library.Core.Interfaces;

namespace JW_Programming_Exercise.Library.Core.Base
{
    /// <summary>
    /// Base class for data entry
    /// </summary>
    public abstract class InputBase : IData
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RobotStartX { get; set; }
        public int RobotStartY { get; set; }
        public Direction InitialDirection { get; set; }
        public IEnumerable<Command> Commands { get; set; }

        public InputBase(bool read = true)
        {
            if (read) Read();
        }

        /// <summary>
        /// Read the data. The child class is forced to implement this method
        /// </summary>
        public abstract void Read();
    }
}