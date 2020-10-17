using System;
using System.Collections.Generic;
using System.IO;
using JW_Programming_Exercise.Library.Core.Enums;
using JW_Programming_Exercise.Library.Core.Interfaces;
using JW_Programming_Exercise.Library.Data;
using NUnit.Framework;

namespace UnitTests
{
    public class DataParseTests
    {
        private IData _data;

        [SetUp]
        public void SetUp()
        {
            Console.SetIn(new StringReader("5 7\n1 2 E\nLRFLRFLRFLRFL\n"));
            _data = new StdinData();
        }

        [Test]
        public void RoomWidthCorrect()
        {
            Assert.AreEqual(_data.RoomWidth, 5);
        }

        [Test]
        public void RoowHeightCorrect()
        {
            Assert.AreEqual(_data.RoomHeight, 7);
        }

        [Test]
        public void RobotStartXCorrect()
        {
            Assert.AreEqual(_data.RobotStartX, 1);
        }

        [Test]
        public void RobotStartYCorrect()
        {
            Assert.AreEqual(_data.RobotStartY, 2);
        }

        [Test]
        public void InitialPositionCorrect()
        {
            Assert.AreEqual(_data.InitialDirection, Direction.East);
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
            Assert.AreEqual(_data.Commands, commands);
        }
    }
}