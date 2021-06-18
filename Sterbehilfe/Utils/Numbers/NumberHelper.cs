﻿using System;

namespace Sterbehilfe.Utils.Numbers
{
    public static class NumberHelper
    {
        public static int Random(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }

        public static double ToDouble(this int i)
        {
            return i;
        }

        public static double ToDouble(this long l)
        {
            return l;
        }

        public static long ToLong(this double d)
        {
            return (long)d;
        }
    }
}