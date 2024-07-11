using AutoMapper;
using CarDealer.GrpcProtos;

namespace CarDealer.Services.Mappers
{
    public class MotorcycleProfile : Profile
    {
        public MotorcycleProfile() {

            CreateMap<Domain.Entities.Vehicles.Motorcycle,
                GrpcProtos.MotorcycleDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.EnergySources, o => o.MapFrom(s => (GrpcProtos.EnergySources)s.EnergySource))
                .ForMember(t => t.Color, o => o.MapFrom(s => new GrpcProtos.Color()
                {
                    R = s.Color.R,
                    B = s.Color.B,
                    G = s.Color.G
                }))
                .ForMember(t => t.HasSideCar, o => o.MapFrom(s => s.HasSideCar))
                .ForMember(t => t.Stock, o => o.MapFrom(s => s.Stock))
                .ForMember(t => t.Price, o => o.MapFrom(s => new GrpcProtos.Price()
                {
                    MoneyType = (GrpcProtos.MoneyTypes)s.Price.Currency,
                    Value = s.Price.Value
                }));

            CreateMap<GrpcProtos.MotorcycleDTO,
                Domain.Entities.Vehicles.Motorcycle > ()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(t => t.EnergySource, o => o.MapFrom(s => (Domain.Types.EnergySource)s.EnergySources))
                .ForMember(t => t.Color, o => o.MapFrom(s => System.Drawing.Color.FromArgb(255,s.Color.R,s.Color.G,s.Color.B)))
                .ForMember(t => t.HasSideCar, o => o.MapFrom(s => s.HasSideCar))
                .ForMember(t => t.Stock, o => o.MapFrom(s => s.Stock))
                .ForMember(t => t.Price, o => o.MapFrom(s => new Domain.ValueObjects.Price(
                    (Domain.Types.MoneyType)s.Price.MoneyType,
                    s.Price.Value)));

        }
    }
}
