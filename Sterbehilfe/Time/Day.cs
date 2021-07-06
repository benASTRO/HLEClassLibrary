﻿using Sterbehilfe.Time.Interfaces;

namespace Sterbehilfe.Time
{
    /// <summary>
    /// A class to do calcutations with the time unit Day.
    /// </summary>
    public class Day : ITimeUnit
    {
        /// <summary>
        /// The amount of days the calculations will be done with.
        /// </summary>
        public int Count { get; set; }

        public long Milliseconds => Count * _inMilliseconds;

        public long Seconds => Milliseconds / 1000;

        /// <summary>
        /// A pattern that will match an expression of days in a <see cref="string"/>.
        /// </summary>
        public const string Pattern = @"\d+d(ay)?s?";

        /// <summary>
        /// One day in milliseconds.
        /// </summary>
        private const long _inMilliseconds = 86400000;

        public Day(int count = 1)
        {
            Count = count;
        }
    }
}