

using CameraClient.CameraManagers;
using CameraClient.Settings;
using OpenCvSharp;

namespace CameraClient
{
    /// <summary>
    /// Represents a camera client that manages camera operations, settings, and definitions.
    /// </summary>
    /// <remarks>
    /// This class provides functionality to interact with cameras, including retrieving frames, 
    /// applying settings, and managing camera definitions. It integrates with OpenCV for camera 
    /// operations and supports dynamic updates to camera settings.
    /// </remarks>
    public class Camera
    {
        /// <summary>
        /// Gets or sets the <see cref="OpenCvManager"/> instance responsible for managing 
        /// OpenCV-based camera operations, such as adjusting settings and retrieving frames.
        /// </summary>
        /// <remarks>
        /// This property is used internally to interact with the OpenCV library for camera-related 
        /// functionalities, including resolution, brightness, contrast, and other camera settings.
        /// </remarks>
        private OpenCvManager OpenCvManager { get; set; }
        /// <summary>
        /// Indicates whether settings change events should be temporarily paused.
        /// </summary>
        /// <remarks>
        /// This field is used to prevent the invocation of settings change event handlers 
        /// during specific operations, such as opening a camera. It ensures that settings 
        /// changes do not trigger unintended behavior while critical operations are in progress.
        /// </remarks>
        private bool _pauseSettingsEvents;
        /// <summary>
        /// Gets or sets the settings for the camera, including properties such as resolution, brightness, contrast, and more.
        /// </summary>
        /// <remarks>
        /// This property provides access to the <see cref="CameraSettings"/> instance, which allows dynamic configuration 
        /// of camera parameters. Changes to the settings trigger events to notify subscribers about updates.
        /// </remarks>
        public CameraSettings Settings { get; set; } = new();
        /// <summary>
        /// Gets the list of cameras available on the current machine.
        /// </summary>
        /// <remarks>
        /// This property contains a collection of <see cref="CameraDefinition"/> objects, 
        /// each representing a camera detected on the machine. The list is populated 
        /// by invoking the <see cref="FindCameraDefinitions"/> method, which uses the 
        /// <see cref="OpenCvManager"/> to discover connected cameras.
        /// </remarks>
        public List<CameraDefinition> CamerasOnMachine { get; private set; } = new();
        /// <summary>
        /// Gets or sets the list of user-defined camera definitions.
        /// </summary>
        /// <remarks>
        /// This property allows the management of custom camera definitions that are 
        /// defined by the user. Each camera definition includes details such as the 
        /// camera's index, name, and available resolutions.
        /// </remarks>
        public List<CameraDefinition> UserDefinedCameras { get; set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraClient.Camera"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the camera client by initializing the <see cref="OpenCvManager"/> 
        /// for managing camera operations and the <see cref="CameraSettings"/> for handling camera settings. 
        /// It also subscribes to the settings change event to dynamically apply updated settings.
        /// </remarks>
        public Camera()
        {
            OpenCvManager = new();
            Settings = new ();
            Settings.OnChangEventHandler += OnChangEventHandler;
        }

        /// <summary>
        /// Handles changes to camera settings by applying the updated values to the camera hardware.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. This parameter is typically the <see cref="CameraSettings"/> instance that triggered the event.
        /// </param>
        /// <param name="e">
        /// An instance of <see cref="ChangedSetting"/> containing the name of the setting that changed and its new value.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the changed setting is not supported.
        /// </exception>
        private void OnChangEventHandler(object? sender, ChangedSetting e)
        {
            if (_pauseSettingsEvents) return;

            switch (e.Name)
            {
                case nameof(CameraSettings.Resolution):
                    OpenCvManager.SetResolution(((CameraResolution)e.NewValue!)!);
                    break;
                case nameof(CameraSettings.Brightness):
                    OpenCvManager.SetBrightness((int)e.NewValue!);
                    break;
                case nameof(CameraSettings.Contrast):
                    OpenCvManager.SetContrast((int)e.NewValue!);
                    break;
                case nameof(CameraSettings.Saturation):
                    OpenCvManager.SetSaturation((int)e.NewValue!);
                    break;
                case nameof(CameraSettings.Exposure):
                    OpenCvManager.SetExposure((int)e.NewValue!);
                    break;
                case nameof(CameraSettings.Gain):
                    OpenCvManager.SetGain((int)e.NewValue!);
                    break;
                default:
                    throw new ArgumentException($"Unsupported setting: {e.Name} = {e.NewValue}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraClient.Camera"/> class with the specified camera settings.
        /// </summary>
        /// <param name="settings">
        /// The <see cref="CameraClient.Settings.CameraSettings"/> instance containing the configuration for the camera.
        /// </param>
        /// <remarks>
        /// This constructor sets up the camera client using the provided settings and initializes the <see cref="OpenCvManager"/> 
        /// for managing camera operations.
        /// </remarks>
        public Camera(CameraSettings settings)
        {
            Settings = settings;
            OpenCvManager = new();
        }

        /// <summary>
        /// Discovers and retrieves a list of camera definitions available on the current machine.
        /// </summary>
        /// <returns>
        /// A list of <see cref="CameraDefinition"/> objects, each representing a detected camera.
        /// </returns>
        /// <remarks>
        /// This method uses the <see cref="OpenCvManager"/> to identify connected cameras and 
        /// populates the <see cref="CamerasOnMachine"/> property with the results. Each camera 
        /// is represented by its index and name.
        /// </remarks>
        public List<CameraDefinition> FindCameraDefinitions()
        {
            CamerasOnMachine = OpenCvManager.FindCameras()
                .Select(c => new CameraDefinition { Index = c.Index, Name = c.Name })
                .ToList();
            return CamerasOnMachine;
        }
        
        /// <summary>
        /// Retrieves the current frame from the camera.
        /// </summary>
        /// <returns>
        /// A <see cref="OpenCvSharp.Mat"/> object representing the captured frame.
        /// </returns>
        /// <remarks>
        /// This method uses the <see cref="CameraClient.CameraManagers.OpenCvManager"/> to capture 
        /// the current frame from the active camera. Ensure that a camera is open before calling this method.
        /// </remarks>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the camera is not open or fails to capture a frame.
        /// </exception>
        public Mat GetFrame()
        {
            return OpenCvManager.GetFrame();
        }

        /// <summary>
        /// Applies the current camera settings to the camera hardware.
        /// </summary>
        /// <remarks>
        /// This method updates the camera's resolution, brightness, contrast, saturation, 
        /// exposure, and gain based on the values specified in the <see cref="Settings"/> property.
        /// It utilizes the <see cref="OpenCvManager"/> to apply these settings to the camera.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the camera hardware is not properly initialized or accessible.
        /// </exception>
        public void ApplyCameraSettings()
        {
            OpenCvManager.SetResolution(Settings.Resolution);
            OpenCvManager.SetBrightness(Settings.Brightness);
            OpenCvManager.SetContrast(Settings.Contrast);
            OpenCvManager.SetSaturation(Settings.Saturation);
            OpenCvManager.SetExposure(Settings.Exposure);
            OpenCvManager.SetGain(Settings.Gain);
        }

        /// <summary>
        /// Opens the camera with the specified name.
        /// </summary>
        /// <param name="cameraName">
        /// The name of the camera to open. This should match the <see cref="CameraClient.Settings.CameraDefinition.Name"/> 
        /// of a camera in the <see cref="CamerasOnMachine"/> list.
        /// </param>
        /// <remarks>
        /// This method attempts to locate the camera by its name in the <see cref="CamerasOnMachine"/> list.
        /// If a matching camera is found, it opens the camera using its corresponding index.
        /// If no matching camera is found, an exception is thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the camera with the specified name cannot be found in the <see cref="CamerasOnMachine"/> list.
        /// </exception>
        public void OpenCamera(string cameraName)
        {
            var cameraDefinition = CamerasOnMachine.FirstOrDefault(c => c.Name == cameraName);
            if (cameraDefinition is null)
            {
                throw new InvalidOperationException($"Camera with name '{cameraName}' not found.  Try refreshing the list of camera's.");
            }
            OpenCamera(cameraDefinition);
        }

        /// <summary>
        /// Opens the camera with the specified camera identifier.
        /// </summary>
        /// <param name="cameraId">
        /// The identifier of the camera to open. This corresponds to the index of the camera 
        /// in the list of available cameras on the machine.
        /// </param>
        /// <remarks>
        /// This method attempts to open the camera using the provided identifier. Ensure that 
        /// the camera identifier corresponds to a valid camera available on the machine.
        /// If no matching camera is found, an exception is thrown.
        /// </remarks>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the camera cannot be opened due to invalid identifier or other operational issues.
        /// </exception>
        public void OpenCamera(int cameraId)
        {

            OpenCamera(new CameraDefinition() {Index = 0, Name = "Unknown"});
        }
        
        public bool IsCameraOpen()
        {
            return OpenCvManager.IsCameraOpen();
        }

        public void OpenCamera(CameraDefinition cameraDef)
        {
            _pauseSettingsEvents = true;
            try
            {
                if (OpenCvManager.IsCameraOpen())
                {
                    OpenCvManager.CloseCamera();
                }

                OpenCvManager.OpenCamera(Settings.CameraId);
                Settings.Resolution = OpenCvManager.GetResolution();
                Settings.Brightness = OpenCvManager.GetBrightness();
                Settings.Contrast = OpenCvManager.GetContrast();
                Settings.Saturation = OpenCvManager.GetSaturation();
                Settings.Exposure = OpenCvManager.GetExposure();
                Settings.Gain = OpenCvManager.GetGain();
            }
            finally
            {
                _pauseSettingsEvents = false;
            }
        }
    }
}
