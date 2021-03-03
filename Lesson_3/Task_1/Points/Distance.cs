using System;
using System.Runtime.InteropServices;

namespace Task_1.Points
{
    public class Distance
    {
        /// <summary>Получить дистанцию между точками.</summary>
        /// <param name="pointOne">Точка 1.</param>
        /// <param name="pointTwo">Точка 2.</param>
        /// <returns>Дистанция между точками.</returns>
        public float GetDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        /// <summary>Получить дистанцию между точками.</summary>
        /// <param name="pointOne">Точка 1.</param>
        /// <param name="pointTwo">Точка 2.</param>
        /// <returns>Дистанция между точками.</returns>
        public double GetDistance(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>Получить дистанцию между точками.</summary>
        /// <param name="pointOne">Точка 1.</param>
        /// <param name="pointTwo">Точка 2.</param>
        /// <returns>Дистанция между точками.</returns>
        public float GetDistance(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        #region GetDistanceNotSqrt

        /// <summary>Получить дистанцию между точками.</summary>
        /// <param name="pointOne">Точка 1.</param>
        /// <param name="pointTwo">Точка 2.</param>
        /// <returns>Дистанция между точками.</returns>
        public float GetDistanceNotSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        private float Root(float number)
        {
            if (number == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = number;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private struct FloatIntUnion
        {
            [FieldOffset(0)]
            public int i;

            [FieldOffset(0)]
            public float f;
        }

        #endregion
    }
}
