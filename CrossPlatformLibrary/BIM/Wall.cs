using System;
using CrossPlatform.Geometry;
using ADSK = Autodesk.Revit.DB;
using BaseElement = CrossPlatform.Library.BaseElement;
using Line = CrossPlatform.Geometry.Line;

namespace CrossPlatform.BIM
{
    public class Wall : BaseElement
    {
        public Line BaseLine { get; set; }
        public double Thickness { get; set; }
        public double Height { get; set; }

        // computed properties
        public double Area => ComputeArea();
        public double Volume => ComputeVolume();
        public double Length => BaseLine.Length;

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



        #endregion
    }
}
