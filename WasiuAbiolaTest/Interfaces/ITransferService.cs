using WasiuAbiolaTest.Dtos;

namespace WasiuAbiolaTest.Interfaces
{
    public interface ITransferService
    {
        Task<TransferResponse> TransferAsync(TransferRequest request);
    }
}
