using System;
using ADSK = Autodesk.Revit.DB;
using CrossPlatform.Interfaces;
using BaseElement = CrossPlatform.Library.BaseElement;
using Line = CrossPlatform.Geometry.Line;
using CrossPlatform.Geometry;

namespace CrossPlatform.BIM
{
    public class Wall :
        BaseElement,
        IRevitInterop<Wall, ADSK.Wall>,
        IRhinoInterop<Wall, Rhino.Geometry.Extrusion>
    {
        public Line BaseLine { get; set; }
        public double Thickness { get; set; }
        public double Height { get; set; }

        // computed properties
        public double Area => ComputeArea();
        public double Volume => ComputeVolume();

        #region constructors

        public Wall()
        {

        }

        #endregion

        #region methods

        private double ComputeArea()
        {
            return (BaseLine.Length * Height) * 2;
        }

        private double ComputeVolume()
        {
            return (BaseLine.Length * Height) * Thickness;
        }

        #endregion

        #region interop

        public Wall FromRevit(ADSK.Wall revitWall)
        {
            Thickness = revitWall.Width;

            // note : this will only work with unconnected walls
            // futher logic would be needed to handle the other cases
            Height = revitWall.get_Parameter(ADSK.BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();

            // get the base curve
            var locationCurve = revitWall.Location as ADSK.LocationCurve;
            BaseLine = new Line()
            {
                StartPoint = new Point().FromRevit(locationCurve.Curve.GetEndPoint(0)),
                EndPoint = new Point().FromRevit(locationCurve.Curve.GetEndPoint(1))
            };

            return this;
        }

        public ADSK.Wall ToRevit()
        {
            throw new System.NotImplementedException();
        }

        public ADSK.Wall ToRevit(ADSK.Document doc = null, ADSK.ElementId levelId = null)
        {
            if (doc == null || levelId == null) throw new ArgumentNullException();

            return ADSK.Wall.Create(
                doc,
                BaseLine.ToRevit(),
                levelId,
                false
                );
        }

        public Wall FromRhino(Rhino.Geometry.Extrusion rhinoObject)
        {
            throw new System.NotImplementedException();
        }

        public Rhino.Geometry.Extrusion ToRhino()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
