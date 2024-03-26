using CarDealer.DataAccess.Abstract.Common;
using CarDealer.Domain.Entities.Types;
using Grpc.Core;

namespace CarDealer.Services.Services
{
    public class PriceService : Price.PriceBase
    {

        private IPriceRepository _priceRepository;

        public PriceService(IPriceRepository repository)
        {
            _priceRepository = repository;
        }

        public override Task<PriceDTO> CreatePrice(CreatePriceRequest request, ServerCallContext context)
        {
            _priceRepository.BeginTransaction();
            var price = _priceRepository.Create((MoneyType)request.MoneyType,request.Value);
            return new Task<PriceDTO>(() => new PriceDTO() { Id = 2, MoneyType = MoneyTypes.Mn, Value = 2});
        }

    }
}
