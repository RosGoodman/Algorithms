
namespace Task_1.Points
{
    public class PointStructDouble
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
        }

        public double Y
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
