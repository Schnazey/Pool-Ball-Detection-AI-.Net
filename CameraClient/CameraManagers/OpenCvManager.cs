using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CameraClient.Settings;
using OpenCvSharp;
using static CameraClient.Win32.Win32Methods;

namespace CameraClient.CameraManagers
{
    internal class OpenCvManager
    {
        protected VideoCapture? Video;

        public List<CameraDefinition> FindCameras()
        {
            List<CameraDefinition> cameraNames = new ();


            try
            {

            }
            catch (Exception e)
            {
                throw new Exceptions.FindCamerasException("Error finding cameras", e);
            }

            return cameraNames;
        }

        public bool IsCameraOpen()
        {
            // check if the camera is open
            return Video != null;
        }

        public void OpenCamera(int cameraId)
        {
            // open a camera to get images using opencvsharp
            Video = new VideoCapture(cameraId);
        }

        public void SetResolution(CameraResolution resolution)
        {
            Video?.Set(VideoCaptureProperties.FrameWidth, resolution.Width);
            Video?.Set(VideoCaptureProperties.FrameHeight, resolution.Height);
        }

        public void SetSaturation(int saturation)
        {
            Video?.Set(VideoCaptureProperties.Saturation, saturation);
        }
        public void SetBrightness(int brightness)
        {
            Video?.Set(VideoCaptureProperties.Brightness, brightness);
        }
        public void SetContrast(int contrast)
        {
            Video?.Set(VideoCaptureProperties.Contrast, contrast);
        }
        public void SetExposure(int exposure)
        {
            Video?.Set(VideoCaptureProperties.Exposure, exposure);
        }
        public void SetGain(int gain)
        {
            Video?.Set(VideoCaptureProperties.Gain, gain);
        }

        public CameraResolution GetResolution()
        {
            // get the current resolution of the camera
            CameraResolution resolution = new CameraResolution();
            resolution.Width = (int)(Video?.Get(VideoCaptureProperties.FrameWidth) ?? 0.0);
            resolution.Height = (int)(Video?.Get(VideoCaptureProperties.FrameHeight) ?? 0.0);
            return resolution;
        }

        public int GetSaturation()
        {
            return (int)(Video?.Get(VideoCaptureProperties.Saturation) ?? 0.0);
        }
        public int GetBrightness()
        {
            return (int)(Video?.Get(VideoCaptureProperties.Brightness) ?? 0.0);
        }
        public int GetContrast()
        {
            return (int)(Video?.Get(VideoCaptureProperties.Contrast) ?? 0.0);
        }

        public int GetExposure()
        {
            return (int)(Video?.Get(VideoCaptureProperties.Exposure) ?? 0.0);
        }

        public int GetGain()
        {
            return (int)(Video?.Get(VideoCaptureProperties.Gain) ?? 0.0);
        }
        public void CloseCamera()
        {
            Video?.Release();
        }

        public Mat GetFrame()
        {
            Mat frame = new Mat();
            if (!IsCameraOpen())
            {
                throw new Exceptions.CameraNotOpenException();
            }
            Video?.Read(frame);
            return frame;
        }

        public int[] ListCameras()
        {
            // list all available cameras
            int[] cameraList = new int[10];
            for (int i = 0; i < 10; i++)
            {
                VideoCapture temp = new VideoCapture(i);
                if (temp.IsOpened())
                {
                    cameraList[i] = i;
                    temp.Release();
                }
                else
                {
                    cameraList[i] = -1;
                }
            }
            return cameraList;
        }
    }
}
