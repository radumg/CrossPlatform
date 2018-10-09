using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace CrossPlatform.Revit
{
    public static class EventHandlers
    {
        public static void RegisterEvents(UIControlledApplication app)
        {
            app.ControlledApplication.DocumentOpened += EventHandlers.OnDocumentOpened;
            app.ControlledApplication.DocumentSynchronizingWithCentral += EventHandlers.OnDocumentSyncStart;
            app.ControlledApplication.DocumentSynchronizedWithCentral += EventHandlers.OnDocumentSyncEnd;
        }

        public static void DeregisterEvents(UIControlledApplication app)
        {
            app.ControlledApplication.DocumentOpened -= EventHandlers.OnDocumentOpened;
            app.ControlledApplication.DocumentSynchronizingWithCentral -= EventHandlers.OnDocumentSyncStart;
            app.ControlledApplication.DocumentSynchronizedWithCentral -= EventHandlers.OnDocumentSyncEnd;
        }


        public static void OnDocumentOpened(object sender, DocumentOpenedEventArgs args)
        {
            var doc = args.Document;
            var localFileName = System.IO.Path.GetFileNameWithoutExtension(doc.PathName);
            var centralFileName = System.IO.Path.GetFileNameWithoutExtension(ModelPathUtils.ConvertModelPathToUserVisiblePath(doc.GetWorksharingCentralModelPath()));

            // do stuff with the info you have
        }

        public static void OnDocumentSyncStart(object sender, DocumentSynchronizingWithCentralEventArgs args)
        {
            var syncOptions = args.Options;
            var syncDocument = args.Document;
            var syncCentralLocation = args.Location;

            // do stuff with the info you have
        }

        public static void OnDocumentSyncEnd(object sender, DocumentSynchronizedWithCentralEventArgs args)
        {
            var syncDocument = args.Document;

            // do stuff with the info you have
        }
    }
}
