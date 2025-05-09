using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Settings
{
    /// <summary>
    /// Represents the definition of a camera, including its index, name, and available resolutions.
    /// </summary>
    public class CameraDefinition
    {
        public int Index;
        /// <summary>
        /// Gets or sets the name of the camera.
        /// </summary>
        /// <remarks>
        /// This property represents the human-readable name of the camera, which can be used to identify it.
        /// </remarks>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the list of available resolutions for the camera.
        /// </summary>
        /// <remarks>
        /// Each resolution is represented by a <see cref="CameraResolution"/> object, 
        /// which specifies the width and height of the resolution.
        /// </remarks>
        public List<CameraResolution> Resolution { get; set; } = new();
    }
}
