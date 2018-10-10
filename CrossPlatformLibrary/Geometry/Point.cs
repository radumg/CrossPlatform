using System;
using Autodesk.Revit.DB;
using CrossPlatform.Interfaces;
using CrossPlatform.Library;

namespace CrossPlatform.Geometry
{
    public class Point :
        BaseElement,
        IRevitInterop<Point, Autodesk.Revit.DB.XYZ>,
        IRhinoInterop<Point, Rhino.Geometry.Point3d>
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

        #region interop
        public Point FromRevit(Autodesk.Revit.DB.XYZ revitPoint)
        {
            if (revitPoint == null) throw new ArgumentNullException();

            X = revitPoint.X;
            Y = revitPoint.Y;
            Z = revitPoint.Z;

            return this;
        }

        public Autodesk.Revit.DB.XYZ ToRevit()
        {
            return new Autodesk.Revit.DB.XYZ(X, Y, Z);
        }

        public XYZ ToRevit(Document doc = null, ElementId hostId = null)
        {
            return ToRevit();
        }

        public Point FromRhino(Rhino.Geometry.Point3d rhinoPoint)
        {
            if (rhinoPoint == null) throw new ArgumentNullException();

            X = rhinoPoint.X;
            Y = rhinoPoint.Y;
            Z = rhinoPoint.Z;

            return this;
        }

        public Rhino.Geometry.Point3d ToRhino()
        {
            return new Rhino.Geometry.Point3d(X, Y, Z);
        }

        #endregion
    }
}
