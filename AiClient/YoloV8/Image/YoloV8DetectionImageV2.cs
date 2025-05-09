using System.Diagnostics;
using System;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using System.Reflection;
using AiClient.Resources;
using Newtonsoft.Json;

namespace AiClient.YoloV8.Image
{
    public class YoloV8DetectionImageV2 : YoloBase
    {
        public string ModelPath = "C:\\Users\\David\\Documents\\runs\\detect\\train\\weights\\best.pt";
        public PersistingPythonClient<ImageResultV2> Client;
        public async Task ProcessImage(int frameId, Mat frame, CancellationToken cancellationToken)
        {
            string scriptPath = ResourceManager.ExtractPythonResource(ResourceManager.YoloV8ImageV2);
            if (Client?.PythonProcess?.HasExited ?? true)
            {
                Client = new PersistingPythonClient<ImageResultV2>(scriptPath, ModelPath);
                Client.Start();
                Task.Run(() => Client.ContinuousRead());

            }
            using (var memoryStream = new MemoryStream())
            {
                var imageBytes = frame.ToBytes(".jpg");
                await Client.Send(frameId, imageBytes);
            }
        }
    }
}
