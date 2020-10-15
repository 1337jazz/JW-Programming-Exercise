using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JW_Programming_Exercise.Library.Shared.Enums;

namespace JW_Programming_Exercise.Library.Shared.Interfaces
{
    public interface IData
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RobotStartX { get; set; }
        public int RobotStartY { get; set; }
        public Direction InitialDirection { get; set; }
        public IEnumerable<Command> Commands { get; set; }
    }
}