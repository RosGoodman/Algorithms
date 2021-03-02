﻿
namespace Task_1.Points
{
    public struct PointStructFloat
    {
        private float _x;
        private float _y;

        public float X
        {
            get { return _x; }
        }

        public float Y
        {
            get { return _y; }
        }

        public PointStructFloat(float x, float y)
        {
            _x = x;
            _y = y;
        }

    }
}
