using AutoMapper;
using CarDealer.DataAccess.Abstract.Common;
using CarDealer.Domain.Entities.Types;
using CarDealer.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CarDealer.Services.Services
{
    public class PriceService : Price.PriceBase
    {

        private IPriceRepository _priceRepository;
        private IMapper _mapper;

        public PriceService(IPriceRepository repository, IMapper mapper)
        {
            _priceRepository = repository;
            _mapper = mapper;
        }

        public override Task<PriceDTO> CreatePrice(CreatePriceRequest request, ServerCallContext context)
        {
            _priceRepository.BeginTransaction();
            var price = _priceRepository.Create((MoneyType)request.MoneyType,request.Value);
            _priceRepository.CommitTransaction();
            return Task.FromResult(_mapper.Map<PriceDTO>(price));
        }

        public override Task<NullablePriceDTO> GetPrice(GetRequest request, ServerCallContext context)
        {
            _priceRepository.BeginTransaction();
            var price = _priceRepository.Get(request.Id);
            _priceRepository.CommitTransaction();

            var result = new NullablePriceDTO();
            if (price is not null)
                result.Price = _mapper.Map<PriceDTO>(price);
            
            return Task.FromResult(result);
        }

        public override Task<Empty> UpdatePrice(PriceDTO request, ServerCallContext context)
        {
            var modifiedPrice = _mapper.Map<CarDealer.Domain.Entities.Common.Price>(request);
            _priceRepository.BeginTransaction();
            _priceRepository.Update(modifiedPrice);
            _priceRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeletePrice(PriceDTO request, ServerCallContext context)
        {
            var price = _mapper.Map<CarDealer.Domain.Entities.Common.Price>(request);
            _priceRepository.BeginTransaction();
            _priceRepository.Delete(price);
            _priceRepository.CommitTransaction();

            return Task.FromResult(new Empty());
        }

    }
}
