using WasiuAbiolaTest.Models;

namespace WasiuAbiolaTest.Data
{
    public class SeedUsers
    {
        public User GetTestUser(long id)
        {
            var sampleeUser = new List<User>
            {
                new User { UserId = 1, WalletBalance = 10000m, DailyTransferLimit = 5000m, TransferredToday = 0m },
            new User { UserId = 2, WalletBalance = 5000m, DailyTransferLimit = 3000m, TransferredToday = 1000m },
            new User { UserId = 3, WalletBalance = 500m, DailyTransferLimit = 2000m, TransferredToday = 0m },
            new User { UserId = 4, WalletBalance = 0m, DailyTransferLimit = 1000m, TransferredToday = 0m }
            };

            return sampleeUser.Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}
