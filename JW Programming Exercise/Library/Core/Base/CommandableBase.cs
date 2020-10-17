using System;
using System.Collections.Generic;
using JW_Programming_Exercise.Library.Core.Enums;

namespace JW_Programming_Exercise.Library.Core.Base
{
    public abstract class CommandableBase
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Direction Direction { get; protected set; }
        public IEnumerable<Command> Commands { get; protected set; }
        public string Result { get; protected set; }

        public virtual void Run()
        {
            ExecuteCommands();
            var direction = (Enum.GetName(typeof(Direction), Direction)).Substring(0, 1);
            Result = $"{X} {Y} {direction}";
        }

        protected abstract void ExecuteCommands();
    }
}