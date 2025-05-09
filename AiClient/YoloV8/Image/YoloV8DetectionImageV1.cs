using System.Diagnostics;
using System;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using System.Reflection;
using AiClient.Resources;
using Newtonsoft.Json;

namespace AiClient.YoloV8.Image
{
    public class YoloV8DetectionImageV1 : YoloBase
    {
        public string ModelPath = "C:\\Users\\David\\Documents\\runs\\detect\\train\\weights\\best.pt";
        
       
        public async Task<List<ImageResult>?> ProcessImage(Mat frame, CancellationToken cancellationToken)
        {
            string scriptPath = ResourceManager.ExtractPythonResource(ResourceManager.YoloV8ImageV1);
            using (var memoryStream = new MemoryStream())
            {
                var imageBytes = frame.ToBytes(".jpg");
                memoryStream.Write(imageBytes, 0, imageBytes.Length);

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"{scriptPath} {ModelPath}",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process { StartInfo = startInfo };
                Stopwatch swStopwatch = Stopwatch.StartNew();
                process.Start();

                process.ErrorDataReceived += (sender, args) => Debug.WriteLine($"Python Error: {args.Data}");
                process.BeginErrorReadLine();


                await process.StandardInput.BaseStream.WriteAsync(imageBytes, 0, imageBytes.Length, cancellationToken);
                await process.StandardInput.BaseStream.FlushAsync(cancellationToken);
                process.StandardInput.Close();

                string jsonOutput = await process.StandardOutput.ReadToEndAsync(cancellationToken);
                await process.WaitForExitAsync(cancellationToken);

                try
                {
                    int jsonStart = jsonOutput.IndexOf("[");

                    if (jsonStart != -1)
                    {
                        if (jsonStart > 0)
                        {
                            Debug.Print(jsonOutput.Substring(0, jsonStart - 1));
                        }
                        jsonOutput = jsonOutput.Substring(jsonStart);
                    }
                    return JsonConvert.DeserializeObject<List<ImageResult>>(jsonOutput);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"DeserializeObject Exception: {ex.Message}");
                    return null;
                }
                // Parse JSON in C#
                
            }

        }
    }
}
