using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Attributes
{
    public class CameraSettingAttribute(int minValue, int maxValue) : Attribute
    {
        public int MinValue { get; set; } = minValue;
        public int MaxValue { get; set; } = maxValue;
    }
}
