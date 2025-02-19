using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IronPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly PdfConverter _converter;
        private readonly ILogger<PdfController> _logger;

        public PdfController(
            PdfConverter converter,
            ILogger<PdfController> logger)
        {
            _converter = converter;
            _logger = logger;
        }

        [HttpGet]
        //public async Task<IActionResult> Get()
        public IActionResult Get()
        {
            var formattedContent = new TemplateFileResponse();

            try
            {
                _logger.LogInformation("Starting PDF conversion...");

                formattedContent.FileData = _converter.Convert("<html>Iron PDF 2021.9.3678 is buggy!</html>");
                formattedContent.FileData = _converter.ConvertFile(@"C:\uptodate\github\ironpdf\IronPdf\AU_AGR_v_1_0_0.html");
                formattedContent.FileType = "application/pdf";

                _logger.LogInformation("Done.");

                var result = File(formattedContent.FileData, formattedContent.FileType); ;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PDF conversion failed");
            }           

            return NoContent();
        }
    }
}
