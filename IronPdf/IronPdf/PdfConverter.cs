using System;
using System.Threading.Tasks;

namespace IronPdf
{
    public class PdfConverter
    {
        public byte[] Convert(string html)
        {
            var renderer = new IronPdf.HtmlToPdf();
            /*
            {
                RenderingOptions = {
                    MarginBottom = 10,
                    MarginRight = 10,
                    MarginLeft = 10,
                    MarginTop = 10,
                }
            };
            */

            var document = renderer.RenderHtmlAsPdf(html);
            var OutputPath = @"C:\uptodate\github\ironpdf\IronPdf\simple.html3.pdf";
            document.SaveAs(OutputPath);
            return document.BinaryData;
        }

        public byte[] ConvertFile(string path)
        {
            // var renderer = new IronPdf.HtmlToPdf();
            var renderer = new ChromePdfRenderer()
            {
                RenderingOptions = {
                    MarginBottom = 10,
                    MarginRight = 10,
                    MarginLeft = 10,
                    MarginTop = 10,
                }
            };
            /*
            renderer.RenderingOptions.CssMediaType = Rendering.PdfCssMediaType.Print;
            renderer.RenderingOptions.PrintHtmlBackgrounds = false;
            renderer.RenderingOptions.CreatePdfFormsFromHtml = false;
            */
            var document = renderer.RenderHTMLFileAsPdf(path);
            var OutputPath = @"C:\uptodate\github\ironpdf\IronPdf\AU_AGR_v_1_0_0.html3.pdf";
            document.SaveAs(OutputPath);

            var document2 = renderer.RenderHTMLFileAsPdf(@"C:\uptodate\github\ironpdf\IronPdf\PR_LTR_v_1_0_0.html");
            var OutputPath2 = @"C:\uptodate\github\ironpdf\IronPdf\PR_LTR_v_1_0_0.pdf";
            document2.SaveAs(OutputPath2);

            return document.BinaryData;
        }
    }
}
