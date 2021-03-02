
namespace Task_1.Points
{
    struct PointStructFloat
    {
        private float _x;
        private float _y;

        internal float X
        {
            get { return _x; }
        }

        internal float Y
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
