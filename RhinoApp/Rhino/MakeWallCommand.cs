﻿using System;
using System.Windows.Forms;
using CrossPlatform.Interop;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;

namespace CrossPlatform.Rhino
{
    public class MakeWallCommand : Command
    {
        public MakeWallCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static MakeWallCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "MakeWall"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            RhinoApp.WriteLine("The {0} command will make a wall from a CrossPlatform.BIM.Wall object.");
            try
            {
                // load the json file from disk
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Please select the CrossPlatform.BIM.Wall json file.";
                DialogResult result = theDialog.ShowDialog();
                if (result != DialogResult.OK) // Test result.
                {
                    RhinoApp.WriteLine("Could not load file.");
                    return Result.Cancel;
                }

                // import the CrossPlatform Wall
                RhinoApp.WriteLine("Importing wall from file : " + theDialog.FileName);
                var wall = CrossPlatform.Library.IO.Json.FromJsonFile<CrossPlatform.BIM.Wall>(theDialog.FileName);

                // make a new Rhino box from wall dimensions
                var brep = WallInterop.ToRhino(wall);

                RhinoApp.WriteLine(CrossPlatform.Library.IO.Json.ToJson(wall));
                if (doc.Objects.AddBrep(brep) == System.Guid.Empty) throw new Exception("Could not add box to document");
                RhinoApp.WriteLine("The {0} command added one wall to the document.");
            }
            catch (Exception e)
            {
                RhinoApp.WriteLine("Something failed miserably : " + e.Message);
                throw;
            }

            doc.Views.Redraw();
            return Result.Success;
        }
    }
}
