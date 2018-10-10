using System;
using CrossPlatform.Interfaces;
using CrossPlatform.Library;

namespace CrossPlatform.Geometry
{
    public class Line : BaseElement
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        // computed
        public double Length => ComputeLength();

        #region constructors

        public Line() : base()
        {
            StartPoint = new Point();
            EndPoint = new Point();
        }

        public Line(Point startPoint, Point endPoint) : base()
        {
            if (startPoint == null || endPoint == null) throw new ArgumentNullException();

            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        #endregion

        #region methods
        private double ComputeLength()
        {
            return Math.Sqrt(
                Math.Pow(EndPoint.X - StartPoint.X, 2) +
                Math.Pow(EndPoint.Y - StartPoint.Y, 2) +
                Math.Pow(EndPoint.Z - StartPoint.Z, 2)
                );
        }

        public Line Reverse()
        {
            var temp = StartPoint;
            StartPoint = EndPoint;
            EndPoint = temp;

            return this;
        }

        #endregion
    }
}
