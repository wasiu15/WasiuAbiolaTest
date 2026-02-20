using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WasiuAbiolaTest.Dtos;
using WasiuAbiolaTest.Interfaces;

namespace WasiuAbiolaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransfersController(ITransferService transferService)
        {
            _transferService = transferService;
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAsync([FromBody] TransferRequest request)
        {
            var transfer = await _transferService.TransferAsync(request);

            return Ok(transfer);
        }
    }
}
