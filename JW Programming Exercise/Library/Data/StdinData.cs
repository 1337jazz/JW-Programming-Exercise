using System;
using System.Collections.Generic;
using System.Linq;
using JW_Programming_Exercise.Library.Shared.Enums;

namespace JW_Programming_Exercise.Library.Data
{
    public class StdinData : InputBase
    {
        public override void Read()
        {
            try
            {
                int[] roomSpecs = ToIntArray(Console.ReadLine());
                int[] robotParams = ToIntArray(Console.ReadLine());
                char[] commands = Console.ReadLine().ToCharArray();
                RoomWidth = roomSpecs[0];
                RoomHeight = roomSpecs[1];
                RobotStartX = robotParams[0];
                RobotStartY = robotParams[1];
                Commands = TranslateCommands(commands);
            }
            catch (Exception e) // Example exception handler
            {
                Console.WriteLine("Invalid data. Process aborted.");
                Console.WriteLine($"Exception details: \n\n {e.Message}");
                Console.ReadLine();
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Splits a string into an array of int
        /// </summary>
        /// <param name="header">The string to split, assumes comma-seperated list of numbers</param>
        /// <returns>The original string represented as an array of int</returns>
        public static int[] ToIntArray(string header)
            => header.Split(',').Select(x => int.Parse(x)).ToArray();

        /// <summary>
        /// Laziliy yield commands to the command list; performance
        /// is greatly improved when command list is very large
        /// </summary>
        /// <param name="arr">The array from which to translate commands</param>
        /// <returns>Yields an iterable list of Command</returns>
        public IEnumerable<Command> TranslateCommands(char[] arr)
        {
            foreach (char command in arr)
            {
                switch (command)
                {
                    case 'L': yield return Command.TurnLeft; break;
                    case 'R': yield return Command.TurnRight; break;
                    case 'F': yield return Command.WalkForward; break;
                    default: break;
                }
            }
        }
    }
}