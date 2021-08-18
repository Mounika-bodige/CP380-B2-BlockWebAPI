using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private Pendingpay pendingPayload;
        public PendingPayloadsController(Pendingpay pendingPayloads)
        {
            pendingPayload = pendingPayloads;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pendingPayload.Payloads);
        }

        [HttpPost]
        public IActionResult Post(Payload payload)
        {
            pendingPayload.Payloads.Add(payload);
            return Ok();
        }
    }
}
