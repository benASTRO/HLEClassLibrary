﻿using System;

namespace HLE.Shapes
{
    /// <summary>
    /// A class to do calculations with a circle.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// The diameter of the circle.
        /// </summary>
        public double Diameter => 2 * Radius;

        /// <summary>
        /// The area of the circle.
        /// </summary>
        public override double Area => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// The circumference of the circle.
        /// </summary>
        public override double Circumference => Diameter * Math.PI;

        /// <summary>
        /// The basic constructor of <see cref="Circle"/>.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }
    }
}
