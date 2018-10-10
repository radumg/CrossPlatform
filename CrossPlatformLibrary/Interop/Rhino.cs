using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.BIM;
using CrossPlatform.Geometry;

namespace CrossPlatform.Interop
{
    public static partial class PointInterop
    {
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
    }

    public static partial class LineInterop
    {
        public static Line FromRhino(Rhino.Geometry.LineCurve rhinoLine)
        {
            if (rhinoLine == null) throw new ArgumentNullException();

            var line = new Line
            {
                StartPoint = PointInterop.FromRhino(rhinoLine.PointAtStart),
                EndPoint = PointInterop.FromRhino(rhinoLine.PointAtEnd)
            };

            return line;
        }

        public static Rhino.Geometry.LineCurve ToRhino(Line source)
        {
            return new Rhino.Geometry.LineCurve(PointInterop.ToRhino(source.StartPoint), PointInterop.ToRhino(source.EndPoint));
        }

    }

    public static partial class WallInterop
    {
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
    }
}
