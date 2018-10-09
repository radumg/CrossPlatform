using System;
using Autodesk.Revit.DB;
using CrossPlatform.Interfaces;
using Rhino.Geometry;
using BaseElement = CrossPlatform.Library.BaseElement;
using Line = CrossPlatform.Geometry.Line;

namespace CrossPlatform.BIM
{
    public class Wall :
        BaseElement,
        IRevitInterop<Wall, Autodesk.Revit.DB.Wall>,
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

        public Wall FromRevit(Autodesk.Revit.DB.Wall revitObject)
        {
            throw new System.NotImplementedException();
        }

        public Autodesk.Revit.DB.Wall ToRevit()
        {
            throw new System.NotImplementedException();
        }

        public Autodesk.Revit.DB.Wall ToRevit(Autodesk.Revit.DB.Document doc = null, Autodesk.Revit.DB.ElementId levelId = null)
        {
            if (doc == null || levelId == null) throw new ArgumentNullException();

            return Autodesk.Revit.DB.Wall.Create(
                doc,
                BaseLine.ToRevit(),
                levelId,
                false
                );
        }

        public Wall FromRhino(Extrusion rhinoObject)
        {
            throw new System.NotImplementedException();
        }

        public Extrusion ToRhino()
        {
            throw new System.NotImplementedException();
        }


        #endregion

    }
}
