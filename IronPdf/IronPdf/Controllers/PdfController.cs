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
        public async Task<IActionResult> Get()
        {
            var formattedContent = new TemplateFileResponse();

            try
            {
                _logger.LogInformation("Starting PDF conversion...");

                formattedContent.FileData = await _converter.Convert("<html>Iron PDF is buggy!</html>");
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
