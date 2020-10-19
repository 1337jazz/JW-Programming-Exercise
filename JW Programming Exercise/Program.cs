using System;
using JW_Programming_Exercise.Library.Data;
using JW_Programming_Exercise.Library.Entities;

namespace JW_Programming_Exercise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Get the data
            var data = new StdinData();

            // Create the robot and give it the data
            var robot = new Robot(data);

            // Run the robot
            robot.Run();

            // Print the results
            Console.WriteLine(robot.Report);
        }
    }
}