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
    public class BlocksController : ControllerBase
    {
        // TODO

        private BlockList blcokl;

        public BlocksController(BlockList blockList)
        {
            blcokl = blockList;
        }


        [HttpGet("/blocks")]
        public IActionResult Get()
        {
            return Ok(blcokl.Chain.Select(block => new Blockdata()
            {
                Hash = block.Hash,
                PreviousHash = block.PreviousHash,
                TimeStamp = block.TimeStamp
            }));
        }

        
        [HttpGet("{hash}")]
        public IActionResult GetBlock(string Hash)
        {
            var block = blcokl.Chain
                .Where(block => block.Hash.Equals(Hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => new Blockdata()
                    {
                        Hash = block.Hash,
                        PreviousHash = block.PreviousHash,
                        TimeStamp = block.TimeStamp
                    }
                    )
                    .First());
            }

            return NotFound();
        }

        [HttpGet("{hash}/Payloads")]
        public IActionResult GetBlockPayload(string Hash)
        {
            var block = blcokl.Chain
                        .Where(block => block.Hash.Equals(Hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => block.Data
                    )
                    .First());
            }

            return NotFound();
        }
    }
}
