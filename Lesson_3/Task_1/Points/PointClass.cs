
namespace Task_1.Points
{
    class PointClass
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

        public PointClass(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
