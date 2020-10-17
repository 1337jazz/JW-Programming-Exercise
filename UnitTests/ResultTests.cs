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
            Assert.AreEqual("1 3 N", _robot.Result);
        }

        [Test]
        public void SecondExample()
        {
            SetData("5 5\n0 0 E\nRFLFFLRF\n");
            Assert.AreEqual("3 1 E", _robot.Result);
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