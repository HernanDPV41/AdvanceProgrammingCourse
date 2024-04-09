using AutoMapper;
using CarDealer.GrpcProtos;

namespace CarDealer.Services.Mappers
{
    public class PriceProfile : Profile
    {
        public PriceProfile() {

            CreateMap<CarDealer.Domain.Entities.Common.Price, PriceDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.MoneyType, o => o.MapFrom(s => s.Currency))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value));

            CreateMap<PriceDTO, CarDealer.Domain.Entities.Common.Price>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.Currency, o => o.MapFrom(s => s.MoneyType))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value));

        }

    }
}
