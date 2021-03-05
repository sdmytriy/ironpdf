using System;
using System.Threading.Tasks;

namespace IronPdf
{
    public class PdfConverter
    {
        public async Task<byte[]> Convert(string html)
        {
            var renderer = new HtmlToPdf
            {
                PrintOptions = {
                    MarginBottom = 10,
                    MarginRight = 10,
                    MarginLeft = 10,
                    MarginTop = 10,
                }
            };

            var document = await renderer.RenderHtmlAsPdfAsync(html);
            return document.BinaryData;
        }
    }
}
