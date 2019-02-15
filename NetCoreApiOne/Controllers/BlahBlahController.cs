using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApiOne.Blah;

namespace NetCoreApiOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlahBlahController : ControllerBase
    {
        private readonly IBlahBlah _blahBlah;
        private readonly ILogger<BlahBlahController> _logger;

        public BlahBlahController(IBlahBlah blahBlah, ILogger<BlahBlahController> logger)
        {
            _blahBlah = blahBlah;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("BlahBlah->Get");
            var blah = await _blahBlah.SomeBlah();
            return Ok(blah);
        }
    }
}