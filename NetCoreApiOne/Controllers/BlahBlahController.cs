using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApiOne.Blah;
using SomeLibrary;

namespace NetCoreApiOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlahBlahController : ControllerBase
    {
        private readonly IBlahBlah _blahBlah;
        private readonly ISomeHelperLibrary1 _someHelperLibrary1;
        private readonly ILogger<BlahBlahController> _logger;

        public BlahBlahController(IBlahBlah blahBlah, ISomeHelperLibrary1 someHelperLibrary1, ILogger<BlahBlahController> logger)
        {
            _blahBlah = blahBlah;
            _someHelperLibrary1 = someHelperLibrary1;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("BlahBlah->Get");
            var blah = await _blahBlah.SomeBlah() + Environment.NewLine + await _someHelperLibrary1.SomeHelper();
            return Ok(blah);
        }
    }
}