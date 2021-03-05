using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronPdf
{
    public class TemplateFileResponse
    {
        public string Error { get; set; }


        public byte[] FileData { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }


        public object Content { get; set; }


        public string ContentType { get; set; }
    }
}
