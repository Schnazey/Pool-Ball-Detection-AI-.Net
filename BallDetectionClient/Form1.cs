using AiClient.YoloV8.Image;
using CameraClient;
using Newtonsoft.Json;
using OpenCvSharp;

namespace BallDetectionClient
{
    public partial class Form1 : Form
    {
        Camera camera = new();
        YoloV8DetectionImageV2 imageModel = new();
        private string lastCaptureError;
        private bool _exiting;
        private Mat? lastFrame;
        bool showImage = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            StartCapture();
        }

        private async void InspectFrameButton_Click(object sender, EventArgs e)
        {
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = new CameraForm();
            cameraForm.Camera = camera;
            cameraForm.ShowDialog();
        }

        private void StartCapture()
        {
            Task.Run(GetCameraFrame);
            camera.OpenCamera(0);
        }


        private async Task GetCameraFrame()
        {
            int frameId = 0;
            while (!_exiting)
            {
                try
                {
                    if (camera.IsCameraOpen())
                    {
                        frameId++;
                        Mat frame = camera.GetFrame();
                        lastFrame = frame.Clone();
                        frames++;
                        if (showImage)
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                        }
                        await imageModel.ProcessImage(frameId, lastFrame, CancellationToken.None);
                        if (imageModel.Client.OnResultReceivedEventHandler == null)
                        {
                            imageModel.Client.OnResultReceivedEventHandler += (sender, result) =>
                            {
                                if (result != null)
                                {
                                    var json = JsonConvert.SerializeObject(result);
                                    lastCaptureError = $"{DateTime.Now} {json}";
                                    Invoke((MethodInvoker)delegate
                                    {
                                        richTextBox1.Text = lastCaptureError;
                                    });
                                }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    lastCaptureError = $"{DateTime.Now} {ex.Message}";
                }
                Thread.Sleep(camera.Settings.FrameDelay);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _exiting = true;
        }

        private void chkShowImage_CheckedChanged(object sender, EventArgs e)
        {
            showImage = chkShowImage.Checked;
        }
        private int frames;
        private int fps;
        private int lastFrames;
        private void FpsTimer_Tick(object sender, EventArgs e)
        {
            fps = (int)((frames - lastFrames) / (FpsTimer.Interval / 1000.0));
            lblFps.Text = $"FPS: {fps}";
            lastFrames = frames;
            frames = lastFrames;
        }
    }
}
