
namespace Task_1.Points
{
    struct PointStructDouble
    {
        private double _x;
        private double _y;

        internal double X
        {
            get { return _x; }
        }

        internal double Y
        {
            get { return _y; }
        }

        public PointStructDouble(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }
}
