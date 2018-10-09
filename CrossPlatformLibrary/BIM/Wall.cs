using CrossPlatform.Interfaces;
using Element = CrossPlatform.Library.Element;
using Line = CrossPlatform.Geometry.Line;

namespace CrossPlatform.BIM
{
    public class Wall : Element, IRevitInterop<Wall,Autodesk.Revit.DB.Wall>
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

        #endregion

    }
}
