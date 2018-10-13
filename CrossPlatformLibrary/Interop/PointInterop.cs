using System;
using CrossPlatform.Geometry;

namespace CrossPlatform.Interop
{
    public static  class PointInterop
    {
        #region Revit
        public static Point FromRevit(Autodesk.Revit.DB.XYZ revitPoint)
        {
            if (revitPoint == null) throw new ArgumentNullException();

            var point = new Point
            {
                X = revitPoint.X,
                Y = revitPoint.Y,
                Z = revitPoint.Z
            };

            return point;
        }

        public static Autodesk.Revit.DB.XYZ ToRevit(Point source)
        {
            return new Autodesk.Revit.DB.XYZ(source.X, source.Y, source.Z);
        }
        #endregion

        #region Rhino
        public static Point FromRhino(Rhino.Geometry.Point3d rhinoPoint)
        {
            if (rhinoPoint == null) throw new ArgumentNullException();

            var point = new Point
            {
                X = rhinoPoint.X,
                Y = rhinoPoint.Y,
                Z = rhinoPoint.Z
            };

            return point;
        }

        public static Rhino.Geometry.Point3d ToRhino(Point source)
        {
            return new Rhino.Geometry.Point3d(source.X, source.Y, source.Z);
        }
        #endregion
    }
}
