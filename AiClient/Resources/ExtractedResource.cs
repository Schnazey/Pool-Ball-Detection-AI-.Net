using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiClient.Resources
{
    public record ExtractedResource
    {
        public string ResourceName { get; set; } = string.Empty;
        public string ExtractedFileName { get; set; } = string.Empty;
    }
}
