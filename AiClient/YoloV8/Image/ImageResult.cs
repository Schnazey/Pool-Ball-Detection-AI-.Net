using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiClient.YoloV8.Image
{
    public class ImageResult
    {
        public string Class { get; set; }
        public float Confidence { get; set; }
        public float[] Box { get; set; } // [x, y, w, h]

    }

    public class ImageResultV2
    {
        public int FrameId { get; set; }
        public ImageResultObjects[] Objects;
    }

    public class ImageResultObjects
    {
        public string Class { get; set; }
        public float Confidence { get; set; }
        public float[] Box { get; set; } // [x, y, w, h]
    }
}
