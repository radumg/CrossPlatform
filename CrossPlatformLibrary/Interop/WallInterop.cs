using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.BIM;
using CrossPlatform.Geometry;

namespace CrossPlatform.Interop
{
    public static class WallInterop
    {
        #region Revit
        public static Wall FromRevit(Autodesk.Revit.DB.Wall revitWall)
        {
            var wall = new Wall();
            wall.Thickness = revitWall.Width;

            // note : this will only work with unconnected walls
            // futher logic would be needed to handle the other cases
            wall.Height = revitWall.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();

            // get the base curve
            var locationCurve = revitWall.Location as Autodesk.Revit.DB.LocationCurve;
            wall.BaseLine = new Line()
            {
                StartPoint = PointInterop.FromRevit(locationCurve.Curve.GetEndPoint(0)),
                EndPoint = PointInterop.FromRevit(locationCurve.Curve.GetEndPoint(1))
            };

            return wall;
        }

        public static Autodesk.Revit.DB.Wall ToRevit(Wall source, Autodesk.Revit.DB.Document doc = null, Autodesk.Revit.DB.ElementId levelId = null)
        {
            if (doc == null || levelId == null) throw new ArgumentNullException();

            return Autodesk.Revit.DB.Wall.Create(
                doc,
                LineInterop.ToRevit(source.BaseLine),
                levelId,
                false
                );
        }
        #endregion

        #region Rhino
        public static Wall FromRhino(Autodesk.Revit.DB.Wall revitWall)
        {
            throw new NotImplementedException();
        }

        public static Rhino.Geometry.Brep ToRhino(Wall wall)
        {
            // i know the coordinates are not right, but it's work in progress and i'm past caring.
            var vector = new Rhino.Geometry.Vector3d(wall.BaseLine.EndPoint.X, wall.BaseLine.EndPoint.Y, wall.BaseLine.EndPoint.Z);
            var origin = new Rhino.Geometry.Point3d(wall.BaseLine.StartPoint.X, wall.BaseLine.StartPoint.Y, wall.BaseLine.StartPoint.Z);
            var plane = new Rhino.Geometry.Plane(origin, vector);
            Rhino.Geometry.Interval xInterval = new Rhino.Geometry.Interval(-wall.Length / 2, wall.Length / 2);
            Rhino.Geometry.Interval yInterval = new Rhino.Geometry.Interval(-wall.Thickness / 2, wall.Thickness / 2);
            Rhino.Geometry.Interval zInterval = new Rhino.Geometry.Interval(0, wall.Height);

            Rhino.Geometry.Box box = new Rhino.Geometry.Box(plane, xInterval, yInterval, zInterval);
            var brep = box.ToBrep();
            brep.Rotate(Math.PI / 2, vector, origin);

            return brep;
        }

        #endregion
    }
}
