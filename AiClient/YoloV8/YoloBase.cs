using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AiClient.Resources;

namespace AiClient.YoloV8
{
    public class YoloBase
    {
        public string ExtractPython()
        {
            return ResourceManager.ExtractPythonResource(ResourceManager.YoloV8ImageV2);
        }
    }
}
