using System.ComponentModel.DataAnnotations;

namespace WasiuAbiolaTest.Dtos
{
    public class TransferRequest
    {
        [Required]
        public long SenderId { get; set; }
        [Required]
        public long ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
