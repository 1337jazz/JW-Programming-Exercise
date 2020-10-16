using System;
using System.Collections.Generic;
using System.IO;
using JW_Programming_Exercise.Library.Data;
using JW_Programming_Exercise.Library.Shared.Enums;
using NUnit.Framework;

namespace UnitTests
{
    public class DataParseTests
    {
        private InputBase Data;

        [SetUp]
        public void SetUp()
        {
            Console.SetIn(new StringReader("5 7\n1 2 E\nLRFLRFLRFLRFL\n"));
            Data = new StdinData();
        }

        [Test]
        public void RoomWidthCorrect()
        {
            Assert.AreEqual(Data.RoomWidth, 5);
        }

        [Test]
        public void RoowHeightCorrect()
        {
            Assert.AreEqual(Data.RoomHeight, 7);
        }

        [Test]
        public void RobotStartXCorrect()
        {
            Assert.AreEqual(Data.RobotStartX, 1);
        }

        [Test]
        public void RobotStartYCorrect()
        {
            Assert.AreEqual(Data.RobotStartY, 2);
        }

        [Test]
        public void InitialPositionCorrect()
        {
            Assert.AreEqual(Data.InitialDirection, Direction.East);
        }

        [Test]
        public void CommandsCorrect()
        {
            // L R F    L R F    L R F    L R F    L
            var commands = new List<Command> {
                Command.TurnLeft,
                Command.TurnRight,
                Command.WalkForward,
                Command.TurnLeft,
                Command.TurnRight,
                Command.WalkForward,
                Command.TurnLeft,
                Command.TurnRight,
                Command.WalkForward,
                Command.TurnLeft,
                Command.TurnRight,
                Command.WalkForward,
                Command.TurnLeft
            };
            Assert.AreEqual(Data.Commands, commands);
        }
    }
}