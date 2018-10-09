using System;
using Autodesk.Revit.DB;
using CrossPlatform.Interfaces;
using CrossPlatform.Library;
using Rhino.Geometry;

namespace CrossPlatform.Geometry
{
    public class Line :
        BaseElement,
        IRevitInterop<Line, Autodesk.Revit.DB.Line>,
        IRhinoInterop<Line, Rhino.Geometry.LineCurve>
    {
        public Point StartPoint { get; internal set; }
        public Point EndPoint { get; internal set; }

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

            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }
        #endregion

        #region methods
        private double ComputeLength()
        {
            return Math.Sqrt(Math.Pow(this.StartPoint.X - this.EndPoint.X, 2) + Math.Pow(this.StartPoint.Y - this.EndPoint.Y, 2) + Math.Pow(this.StartPoint.Z - this.EndPoint.Z, 2));
        }

        public Line Reverse()
        {
            var temp = StartPoint;
            StartPoint = EndPoint;
            EndPoint = temp;

            return this;
        }
        #endregion

        #region interop
        public Line FromRevit(Autodesk.Revit.DB.Line revitLine)
        {
            if (revitLine == null) throw new ArgumentNullException();

            this.StartPoint = new Point().FromRevit(revitLine.GetEndPoint(0));
            this.EndPoint = new Point().FromRevit(revitLine.GetEndPoint(1));

            return this;
        }

        public Autodesk.Revit.DB.Line ToRevit()
        {
            var start = this.StartPoint.ToRevit();
            var end = this.EndPoint.ToRevit();

            return Autodesk.Revit.DB.Line.CreateBound(start, end);
        }

        public Autodesk.Revit.DB.Line ToRevit(Document doc = null, ElementId hostId = null)
        {
            return ToRevit();
        }

        public Line FromRhino(Rhino.Geometry.LineCurve rhinoLine)
        {
            if (rhinoLine == null) throw new ArgumentNullException();

            this.StartPoint = new Point().FromRhino(rhinoLine.PointAtStart);
            this.EndPoint = new Point().FromRhino(rhinoLine.PointAtEnd);

            return this;
        }

        public Rhino.Geometry.LineCurve ToRhino()
        {
            return new Rhino.Geometry.LineCurve(StartPoint.ToRhino(), EndPoint.ToRhino());
        }

        #endregion
    }
}
