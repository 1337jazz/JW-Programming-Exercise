using System;
using System.IO;
using JW_Programming_Exercise.Library.Core.Interfaces;
using JW_Programming_Exercise.Library.Data;
using JW_Programming_Exercise.Library.Entities;
using NUnit.Framework;

namespace UnitTests
{
    public class ResultTests
    {
        private IData _data;
        private Robot _robot;

        [Test]
        public void FirstExample()
        {
            SetData("5 5\n1 2 N\nRFRFFRFRF\n");
            Assert.AreEqual("Report: 1 3 N", _robot.Report);
        }

        [Test]
        public void SecondExample()
        {
            SetData("5 5\n0 0 E\nRFLFFLRF\n");
            Assert.AreEqual("Report: 3 1 E", _robot.Report);
        }

        [Test]
        public void CustomExample()
        {
            SetData("5 2\n0 1 N\nRFFFRFLL\n");
            Assert.AreEqual("Report: 3 2 N", _robot.Report);
        }

        [Test]
        public void HandlesSmallestRoom()
        {
            SetData("0 0\n0 0 E\nRFLFFLRF\n");
            Assert.AreEqual("Report: 0 0 E", _robot.Report);
        }

        [Test]
        public void RobotCannotPassThroughNorthWall()
        {
            SetData("5 5\n0 3 N\nFFFF\n");
            Assert.AreEqual("Report: 0 0 N", _robot.Report);
        }

        [Test]
        public void RobotCannotPassThroughEastWall()
        {
            SetData("5 5\n0 0 E\nFFFFFFFFF\n");
            Assert.AreEqual("Report: 5 0 E", _robot.Report);
        }

        [Test]
        public void RobotCannotPassThroughSouthWall()
        {
            SetData("5 5\n0 0 S\nFFFFFFFFF\n");
            Assert.AreEqual("Report: 0 5 S", _robot.Report);
        }

        [Test]
        public void RobotCannotPassThroughWestWall()
        {
            SetData("5 5\n5 0 W\nFFFFFFFFF\n");
            Assert.AreEqual("Report: 0 0 W", _robot.Report);
        }

        [Test]
        public void RobotFollowsFurtherInstructionsAfterBump()
        {
            SetData("5 5\n0 3 N\nFFFFL\n");
            Assert.AreEqual("Report: 0 0 W", _robot.Report);
        }

        [Test]
        public void RobotIgnoresInvalidCommands()
        {
            SetData("5 5\n1 2 N\nR!FR£FF.,/R4FRF[%^ ¬ ###d@B\n");
            Assert.AreEqual("Report: 1 3 N", _robot.Report);
        }

        [Test]
        public void ExceptionOnInvalidData()
        {
            SetData("invalid data!");
            Assert.AreEqual("Invalid data", _robot.Report);
        }

        private void SetData(string data)
        {
            Console.SetIn(new StringReader(data));
            _data = new StdinData();
            _robot = new Robot(_data);
            _robot.Run();
        }
    }
}