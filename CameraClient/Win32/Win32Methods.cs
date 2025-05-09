using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Win32
{
    /// <summary>
    /// Provides a collection of methods and structures for interacting with Win32 APIs related to video capture devices.
    /// </summary>
    /// <remarks>
    /// This class contains P/Invoke declarations for functions and structures from the "avicap32.dll" library, 
    /// which are used to enumerate and retrieve capabilities of video capture devices.
    /// </remarks>
    internal class Win32Methods
    {
        /// <summary>
        /// Retrieves the capabilities of a specified video capture device.
        /// </summary>
        /// <param name="hDev">A handle to the video capture device.</param>
        /// <param name="caps">
        /// A reference to a <see cref="CapDeviceCaps"/> structure that receives the device capabilities.
        /// </param>
        /// <returns>
        /// An integer indicating the result of the operation. A non-zero value typically indicates success, 
        /// while a zero value indicates failure.
        /// </returns>
        /// <remarks>
        /// This method is a P/Invoke declaration for the "capGetDeviceCaps" function in the "avicap32.dll" library. 
        /// It is used to query the capabilities of a video capture device, such as its supported resolutions, 
        /// frame rates, and other hardware-specific features.
        /// </remarks>
        [DllImport("avicap32.dll")]
        public static extern int CapGetDeviceCaps(int hDev, ref CapDeviceCaps caps);

        /// <summary>
        /// Enumerates video capture devices available on the system.
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the parent window that owns the dialog box used for device enumeration. 
        /// This parameter can be set to 0 if no parent window is specified.
        /// </param>
        /// <param name="nIndex">
        /// The zero-based index of the video capture device to retrieve information for.
        /// </param>
        /// <param name="devInfo">
        /// A reference to a <see cref="CapDevInfo"/> structure that receives information about the video capture device.
        /// </param>
        /// <param name="cbDevInfo">
        /// The size, in bytes, of the <see cref="CapDevInfo"/> structure.
        /// </param>
        /// <returns>
        /// An integer indicating the result of the operation. A non-zero value typically indicates success, 
        /// while a zero value indicates failure.
        /// </returns>
        /// <remarks>
        /// This method is a P/Invoke declaration for the "capEnumVideoDevs" function in the "avicap32.dll" library. 
        /// It is used to enumerate video capture devices by retrieving their details one at a time, based on the specified index.
        /// </remarks>
        [DllImport("avicap32.dll")]
        public static extern int CapEnumVideoDevs(int hwndParent, int nIndex, ref CapDevInfo devInfo, int cbDevInfo);

        /// <summary>
        /// Represents the capabilities of a video capture device.
        /// </summary>
        /// <remarks>
        /// This structure is used to store information about the minimum, maximum, default, 
        /// and supported capabilities of a video capture device. It is typically populated 
        /// by calling the <see cref="Win32Methods.CapGetDeviceCaps"/> method.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct CapDeviceCaps
        {
            public int cb;
            public int dwMin;
            public int dwMax;
            public int dwDefault;
            public int dwCaps;
        }

        /// <summary>
        /// Represents information about a video capture device, including its name, flags, driver, and handle.
        /// </summary>
        /// <remarks>
        /// This structure is used in conjunction with the <see cref="Win32Methods.CapEnumVideoDevs"/> method 
        /// to enumerate and retrieve details about video capture devices available on the system.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct CapDevInfo
        {
            public int cbStruct;
            public byte[] szName; 
            public int dwFlags;
            public int dwDriver;
            public int hDev; 
        }
    }
}
