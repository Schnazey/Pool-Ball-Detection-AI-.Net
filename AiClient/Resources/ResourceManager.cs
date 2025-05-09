using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AiClient.YoloV8.Image;

namespace AiClient.Resources
{
    public static class ResourceManager
    {
        public const string YoloV8ImageV1 = "AiClient.Resources.Python.Detection.YoloV8ImageV1.py";
        public const string YoloV8ImageV2 = "AiClient.Resources.Python.Detection.YoloV8ImageV2.py";

        public static List<ExtractedResource> ExtractedResources = new List<ExtractedResource>();

        public static string ExtractPythonResource(string resource)
        {
            string fileName = string.Join(".", resource.Split('.').TakeLast(2));
            var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                "AiClient",
                "Python", 
                fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            ExtractResource(resource, fullPath);
            return fullPath;
        }

        public static void ExtractResource(string resource, string fileName)
        {
            if (ExtractedResources.Exists(resourceObject =>
                    resourceObject.ResourceName == resource && resourceObject.ExtractedFileName == fileName))
            {
                return;
            }
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                if (stream == null)
                {
                    throw new ArgumentException("Resource not found", nameof(resource));
                }


                using (FileStream fileStream =
                       new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
            ExtractedResources.Add(new ExtractedResource(){ExtractedFileName = fileName, ResourceName = resource});
        }
    }
}
