using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentStatusController : ControllerBase
    {
        private readonly ILogger<DocumentStatusController> _logger;

        public DocumentStatusController(ILogger<DocumentStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DocumentStatusInfo), StatusCodes.Status200OK)]
        public IActionResult Get(long id)
        {
            var mockObject = new DocumentStatusInfo(id, DocumentStatus.New);
            return Ok(mockObject);
        }
    }

    public class DocumentStatusInfo
    {
        public DocumentStatusInfo(long id, DocumentStatus status)
        {
            Id = id;
            Status = status;
        }
        public long Id { get; }
        public DocumentStatus Status { get; }
        public string Name => Status.ToString();
    }
    
    public enum DocumentStatus
    {
        New
    }
}
