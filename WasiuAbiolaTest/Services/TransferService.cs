using WasiuAbiolaTest.Data;
using WasiuAbiolaTest.Dtos;
using WasiuAbiolaTest.Interfaces;
using WasiuAbiolaTest.Models;

namespace WasiuAbiolaTest.Services
{

    
    public class TransferService : ITransferService
    {
        //  THINGS I COULD IMPROVE::

        //  HAVE A GENERIC RESPONSE HELPER
        //  USE A REAL DATABASE
        //  IMPLEMENT LOCKING FOR TRANSACTION
        //  USE ROW VERSION 
        //  ADD LOGGING
        //  ADD MORE TABLES LIKE TRANSACTION AND HAVE THE LIMITS ON A SEPERATE PLACE
        //  UPDATE TRANSACTION STATUS AS WELL IN THE DATABASE
        //  

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


        public async Task<TransferResponse> TransferAsync(TransferRequest request)
        {
            try
            {
                if (request.Amount <= 0)
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "Invalid amount"
                    };
                }

                if (request.SenderId == request.ReceiverId)
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "You can't send to self"
                    };
                }

                var senderAccount = GetTestUser(request.SenderId);
                if (senderAccount == null)
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "Sender not found"
                    };
                }

                var receiverAccount = GetTestUser(request.ReceiverId);
                if (receiverAccount == null)
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "Receiver not found"
                    };
                }


                // LOCK THE TRANSACTION HERE but I"m using a seeded data

                if (senderAccount.WalletBalance < request.Amount)
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "Insufficient balance"
                    };
                }

                if (senderAccount.DailyTransferLimit < (request.Amount + senderAccount.TransferredToday))
                {
                    return new TransferResponse
                    {
                        Success = false,
                        Message = "Daily transfer limit exceeded"
                    };
                }

                senderAccount.WalletBalance -= request.Amount;
                receiverAccount.WalletBalance += request.Amount;
                senderAccount.TransferredToday += request.Amount;


                // commit transaction and release lock

                return new TransferResponse
                {
                    Success = true,
                    Message = "Transfer successful"
                };

            }
            catch (Exception ex)
            {
                // roll back transaction
                // log error

                return new TransferResponse
                {
                    Success = false,
                    Message = "Something went wrong"
                };
            }

        }


        
    }
}
