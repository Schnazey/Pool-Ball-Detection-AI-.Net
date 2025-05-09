using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AiClient.YoloV8.Image;
using Newtonsoft.Json;

namespace AiClient
{
    public class PersistingPythonClient<TResult>
    {
        public Process? PythonProcess { get; set; }
        public string PythonClientPath { get; set; }
        public string ModelPath { get; set; }
        public bool MustStop {get; set; }

        public EventHandler<TResult?> OnResultReceivedEventHandler;

        public PersistingPythonClient(string pythonClientPath, string modelPath)
        {
            PythonClientPath = pythonClientPath;
            ModelPath = modelPath;
        }

        public async Task Send(int frameId, byte[] data)
        {
            try
            {
                string frameMetadata = $"{{\"frame_id\": {frameId}}}\n";  // Newline for separation
                await PythonProcess!.StandardInput.BaseStream.WriteAsync(Encoding.UTF8.GetBytes(frameMetadata));
                await PythonProcess.StandardInput.BaseStream.WriteAsync(data, 0, data.Length);
                await PythonProcess.StandardInput.BaseStream.WriteAsync("\nEND\n"u8.ToArray());
                await PythonProcess.StandardInput.BaseStream.FlushAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task ContinuousRead()
        {
            while (!PythonProcess.StandardOutput.EndOfStream)
            {
                string? jsonOutput = await PythonProcess.StandardOutput.ReadLineAsync();

                if (!string.IsNullOrWhiteSpace(jsonOutput))
                {
                    try
                    {
                        var detections = JsonConvert.DeserializeObject<TResult>(jsonOutput);
                        OnResultReceivedEventHandler?.Invoke(this, detections);
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"Error parsing JSON: {ex.Message}");
                    }
                }
            }
        }

        public void Start()
        {
            if (PythonProcess?.HasExited ?? true)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"{PythonClientPath} {ModelPath}",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                PythonProcess = new Process { StartInfo = startInfo };
                PythonProcess.Start();

                PythonProcess.ErrorDataReceived += (sender, args) => Debug.WriteLine($"Python Error: {args.Data}");
                PythonProcess.BeginErrorReadLine();
            }
        }

    }
}
