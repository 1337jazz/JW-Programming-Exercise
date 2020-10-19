using System;
using System.Collections.Generic;
using System.Linq;
using JW_Programming_Exercise.Library.Core.Base;
using JW_Programming_Exercise.Library.Core.Enums;

namespace JW_Programming_Exercise.Library.Data
{
    /// <summary>
    /// Standard I/O implementation of InputBase/IData
    /// </summary>
    public class StdinData : InputBase
    {
        /// <summary>
        /// The main method to read input. Overridden from base class.
        /// </summary>
        public override void Read()
        {
            try
            {
                // Read the input streams
                int[] roomSpecs = ToIntArray(Console.ReadLine());
                string robotParams = Console.ReadLine().Replace(" ", "");
                char[] commands = Console.ReadLine().ToCharArray();

                // Parse room specs
                RoomWidth = roomSpecs[0];
                RoomHeight = roomSpecs[1];

                // Parse robot params
                RobotStartX = int.Parse(robotParams[0].ToString());
                RobotStartY = int.Parse(robotParams[1].ToString());
                InitialDirection = TranslateDirection(robotParams[2]);

                // Parse commands
                Commands = TranslateCommands(commands);
            }
            catch (Exception) // Example exception handler
            {
                IsError = true;
            }
        }

        /// <summary>
        /// Splits a string into an array of int
        /// </summary>
        /// <param name="header">The string to split, assumes comma-seperated list of numbers</param>
        /// <param name="splitChar">The char to split by, 'space char' by default</param>
        /// <returns>The original string represented as an array of int</returns>
        public static int[] ToIntArray(string str, char splitChar = ' ')
            => str.Split(splitChar).Select(x => int.Parse(x)).ToArray();

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
                switch (command.ToString().ToUpper())
                {
                    case "L": yield return Command.TurnLeft; break;
                    case "R": yield return Command.TurnRight; break;
                    case "F": yield return Command.WalkForward; break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// Translate a direction from char to type of Direction.
        /// </summary>
        /// <param name="direction">The direction char to translate</param>
        /// <returns>Direction type. Returns North by default.</returns>
        public Direction TranslateDirection(char direction)
        {
            return (direction.ToString().ToUpper()) switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => Direction.North,
            };
        }
    }
}