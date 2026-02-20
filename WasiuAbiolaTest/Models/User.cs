namespace WasiuAbiolaTest.Models
{
    public class User
    {
        public long UserId { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal DailyTransferLimit { get; set; }
        public decimal TransferredToday { get; set; }
    }
}
