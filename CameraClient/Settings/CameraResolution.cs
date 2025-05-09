using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Settings
{
    /// <summary>
    /// Represents the resolution of a camera, defined by its width and height.
    /// </summary>
    /// <remarks>
    /// This class is used to specify the dimensions of a camera's resolution, 
    /// including the width (in pixels) and height (in pixels).
    /// </remarks>
    public class CameraResolution
    {
        /// <summary>
        /// Gets or sets the width of the camera resolution in pixels.
        /// </summary>
        /// <value>
        /// An integer representing the width of the resolution in pixels.
        /// </value>
        /// <remarks>
        /// This property is used to define or retrieve the horizontal dimension of the camera's resolution.
        /// </remarks>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the height of the camera resolution in pixels.
        /// </summary>
        /// <value>
        /// An integer representing the height of the resolution in pixels.
        /// </value>
        /// <remarks>
        /// This property is used to define or retrieve the vertical dimension of the camera's resolution.
        /// </remarks>
        public int Height { get; set; }
    }
}
