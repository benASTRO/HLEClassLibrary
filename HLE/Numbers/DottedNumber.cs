﻿#pragma warning disable CS0661, CS0659, CS1591


namespace HLE.Numbers
{
    /// <summary>
    /// Creates a number in which every three digits are devided by a dot.<br />
    /// Works with positive and negative values.<br />
    /// For example: 1.465.564
    /// </summary>
    public struct DottedNumber
    {
        /// <summary>
        /// The number with the dots inserted displayed as a <see cref="string"/>.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// The original number passed to the constructor.
        /// </summary>
        public long OrigninalNumber { get; private set; }

        /// <summary>
        /// The basic constructor of <see cref="DottedNumber"/>.
        /// </summary>
        /// <param name="number">A number of type <see cref="long"/> in which the dots will be inserted</param>
        public DottedNumber(long number)
        {
            OrigninalNumber = number;
            bool negative = OrigninalNumber < 0;
            string num = negative ? OrigninalNumber.ToString()[1..] : OrigninalNumber.ToString();

            if (num.Length >= 4)
            {
                for (int i = num.Length - 3; i > 0; i -= 3)
                {
                    num = num.Insert(i, ".");
                }
            }

            Number = negative ? $"-{num}" : num;
        }

        public static bool operator ==(DottedNumber left, DottedNumber right)
        {
            return left.OrigninalNumber == right.OrigninalNumber;
        }

        public static bool operator !=(DottedNumber left, DottedNumber right)
        {
            return !(left == right);
        }

        public static bool operator >(DottedNumber left, DottedNumber right)
        {
            return left.OrigninalNumber > right.OrigninalNumber;
        }

        public static bool operator <(DottedNumber left, DottedNumber right)
        {
            return left.OrigninalNumber < right.OrigninalNumber;
        }

        public static bool operator >=(DottedNumber left, DottedNumber right)
        {
            return left.OrigninalNumber >= right.OrigninalNumber;
        }

        public static bool operator <=(DottedNumber left, DottedNumber right)
        {
            return left.OrigninalNumber <= right.OrigninalNumber;
        }

        public static DottedNumber operator +(DottedNumber left, DottedNumber right)
        {
            return new(left.OrigninalNumber + right.OrigninalNumber);
        }

        public static DottedNumber operator -(DottedNumber left, DottedNumber right)
        {
            return new(left.OrigninalNumber - right.OrigninalNumber);
        }

        public static DottedNumber operator *(DottedNumber left, DottedNumber right)
        {
            return new(left.OrigninalNumber * right.OrigninalNumber);
        }

        public static DottedNumber operator /(DottedNumber left, DottedNumber right)
        {
            return new(left.OrigninalNumber / right.OrigninalNumber);
        }

        public static DottedNumber operator ++(DottedNumber dottedNumber)
        {
            return new(dottedNumber.OrigninalNumber + 1);
        }

        public static DottedNumber operator --(DottedNumber dottedNumber)
        {
            return new(dottedNumber.OrigninalNumber - 1);
        }

        public static DottedNumber operator !(DottedNumber dottedNumber)
        {
            return new DottedNumber(-dottedNumber.OrigninalNumber);
        }

        public static implicit operator long(DottedNumber dottedNumber)
        {
            return dottedNumber.OrigninalNumber;
        }

        public static implicit operator DottedNumber(long l)
        {
            return new DottedNumber(l);
        }

        public bool Equals(DottedNumber dottedNumber)
        {
            return this == dottedNumber;
        }

        public bool Equals(long number)
        {
            return this == new DottedNumber(number);
        }

        public override bool Equals(object? obj)
        {
            return obj is DottedNumber d && this == d;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
