using CrossPlatform.Library;

namespace CrossPlatform.Geometry
{
    public class Point : BaseElement
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #region constructors
        public Point() : base()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point(double x, double y, double z) : base()
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion
    }
}
