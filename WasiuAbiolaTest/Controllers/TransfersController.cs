using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WasiuAbiolaTest.Dtos;

namespace WasiuAbiolaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        [HttpPost("transfer")]
        public IActionResult TransferAsync([FromBody] TransferRequest request)
        {

            return Ok(new { message = "Transfer successful" });
        }
    }
}
