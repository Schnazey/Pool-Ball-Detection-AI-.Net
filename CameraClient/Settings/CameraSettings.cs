using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using CameraClient.Attributes;

namespace CameraClient.Settings
{
    /// <summary>
    /// Represents the settings for a camera, including properties such as resolution, brightness, contrast, and more.
    /// </summary>
    /// <remarks>
    /// This class provides mechanisms to manage and update camera settings dynamically. 
    /// Changes to properties trigger events to notify subscribers about the updates.
    /// </remarks>
    public class CameraSettings
    {
        private int _cameraId;
        private string _cameraName;
        private CameraResolution _resolution = new();
        private int _brightness = 0;
        private int _contrast = 0;
        private int _saturation = 0;
        private int _exposure = 0;
        private int _gain = 0;
        private List<CameraResolution> _resolutions = new();

        public EventHandler<ChangedSetting> OnChangEventHandler;
        private int _frameDelay = 100;

        /// <summary>
        /// Gets or sets the name of the camera.
        /// </summary>
        /// <remarks>
        /// Changing this property triggers the <see cref="OnChangEventHandler"/> event to notify subscribers
        /// about the update. The event provides the old and new values of the camera name.
        /// </remarks>
        public string CameraName
        {
            get { return _cameraName.ToString(); }
            set
            {
                if (value == _cameraName) return;
                string oldValue = _cameraName;
                _cameraName = value;
                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(CameraName), oldValue, value));
                }
                finally
                {
                    _cameraName = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the camera.
        /// </summary>
        /// <remarks>
        /// This property is used to specify or retrieve the ID of the camera being managed.
        /// Changing this property triggers the <see cref="OnChangEventHandler"/> event to notify subscribers about the update.
        /// </remarks>
        public int CameraId
        {
            get => _cameraId;
            set
            {
                if (_cameraId == value) return;
                int oldValue = _cameraId;
                _cameraId = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(CameraId), oldValue, value));
                }
                finally
                {
                    _cameraId = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resolution of the camera.
        /// </summary>
        /// <remarks>
        /// This property defines the dimensions of the camera's resolution, including width and height in pixels.
        /// Changes to this property trigger an event to notify subscribers about the update.
        /// </remarks>
        public CameraResolution Resolution
        {
            get => _resolution;
            set
            {
                if (_resolution == value) return;
                CameraResolution oldValue = _resolution;
                _resolution = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Resolution), oldValue, value));
                }
                finally
                {
                    _resolution = oldValue;
                }
            }
        }

        [CameraSettingAttribute(1, 60000)]
        public int FrameDelay
        {
            get => _frameDelay;
            set
            {
                if (_frameDelay == value) return;
                int oldValue = _frameDelay;
                _frameDelay = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(FrameDelay), oldValue, value));
                }
                finally
                {
                    _frameDelay = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the brightness level of the camera.
        /// </summary>
        /// <remarks>
        /// Adjusting this property triggers an event to notify subscribers of the change.
        /// The brightness value is used to control the camera's image brightness dynamically.
        /// </remarks>
        /// <value>
        /// An <see cref="int"/> representing the brightness level. 
        /// </value>
        /// <exception cref="ArgumentException">
        /// Thrown if the brightness value is invalid or unsupported.
        /// </exception>
        [CameraSettingAttribute(0, 100)]
        public int Brightness
        {
            get => _brightness;
            set
            {
                if (_brightness == value) return;
                int oldValue = _brightness;
                _brightness = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Brightness), oldValue, value));
                }
                finally
                {
                    _brightness = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the contrast level of the camera.
        /// </summary>
        /// <remarks>
        /// Adjusting the contrast level affects the difference in luminance or color
        /// that makes an object distinguishable from others within the image. Changes
        /// to this property trigger an event to notify subscribers about the update.
        /// </remarks>
        /// <value>
        /// An integer representing the contrast level. The default value is 0.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Thrown if the contrast value is invalid or unsupported.
        /// </exception>
        [CameraSettingAttribute(0, 100)]
        public int Contrast
        {
            get => _contrast;
            set
            {
                if (_contrast == value) return;
                int oldValue = _contrast;
                _contrast = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Contrast), oldValue, value));
                }
                finally
                {
                    _contrast = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the saturation level of the camera.
        /// </summary>
        /// <remarks>
        /// The saturation level determines the intensity of colors in the camera's output.
        /// Changes to this property trigger the <see cref="OnChangEventHandler"/> event to notify subscribers.
        /// </remarks>
        /// <value>
        /// An integer representing the saturation level. The default value is 0.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Thrown if an unsupported setting name is encountered during event handling.
        /// </exception>
        [CameraSettingAttribute(0, 100)]
        public int Saturation
        {
            get => _saturation;
            set
            {
                if (_saturation == value) return;
                int oldValue = _saturation;
                _saturation = value;
                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Saturation), oldValue, value));
                }
                finally
                {
                    _saturation = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the exposure level of the camera.
        /// </summary>
        /// <remarks>
        /// The exposure level determines the amount of light captured by the camera sensor. 
        /// Adjusting this value affects the brightness of the captured image.
        /// Changes to this property trigger the <see cref="OnChangEventHandler"/> event to notify subscribers.
        /// </remarks>
        /// <value>
        /// An integer representing the exposure level. The default value is 0.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Thrown when an unsupported setting is modified.
        /// </exception>
        [CameraSettingAttribute(0, 100)]
        public int Exposure
        {
            get => _exposure;
            set
            {
                if (_exposure == value) return;
                int oldValue = _exposure;
                _exposure = value;

                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Exposure), oldValue, value));
                }
                finally
                {
                    _exposure = oldValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the gain level of the camera.
        /// </summary>
        /// <remarks>
        /// The gain level adjusts the amplification of the camera's signal, which can affect the brightness and noise of the image.
        /// Changes to this property trigger the <see cref="OnChangEventHandler"/> event to notify subscribers about the update.
        /// </remarks>
        /// <value>
        /// An integer representing the gain level of the camera. The default value is 0.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Thrown if the gain level change is not supported by the camera.
        /// </exception>
        [CameraSettingAttribute(0, 100)]
        public int Gain
        {
            get => _gain;
            set
            {
                if (_gain == value) return;
                int oldValue = _gain;
                _gain = value;
                try
                {
                    OnChangEventHandler?.Invoke(this, new ChangedSetting(nameof(Gain), oldValue, value));
                }
                finally
                {
                    _gain = oldValue;
                }
            }
        }
    }
}