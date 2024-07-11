using AutoMapper;
using CarDealer.Application.Vehicles.Commands.CreateMotorcycle;
using CarDealer.Application.Vehicles.Commands.DeleteMotorcycle;
using CarDealer.Application.Vehicles.Commands.UpdateMotorcycle;
using CarDealer.Application.Vehicles.Queries.GetAllMotorcycles;
using CarDealer.Application.Vehicles.Queries.GetMotorcycleById;
using CarDealer.Domain.Types;
using CarDealer.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace CarDealer.Services.Services
{
    public class MotorcycleService : Motorcycle.MotorcycleBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MotorcycleService(
            IMediator mediator,
            IMapper mapper) 
        { 
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<MotorcycleDTO> CreateMotorcycle(CreateMotorcycleRequest request, ServerCallContext context)
        {
            var command = new CreateMotorcycleCommand(
                request.Brand,
                (EnergySource)request.EnergySources,
                new Domain.ValueObjects.Price(
                    (MoneyType)request.Price.MoneyType,
                    request.Price.Value));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<MotorcycleDTO>(result));
        }

        public override Task<NullableMotorcycleDTO> GetMotorcycle(GetRequest request, ServerCallContext context)
        {
            var query = new GetMotorcycleByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableMotorcycleDTO() { Null = NullValue.NullValue}); 
            return Task.FromResult(new NullableMotorcycleDTO() { Motorcycle = _mapper.Map<MotorcycleDTO>(result) });
        }

        public override Task<Motorcycles> GetAllMotorcycles(Empty request, ServerCallContext context)
        {
            var query = new GetAllMotorcyclesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de motocicletas al mensaje de lista de DTOs de motocicletas.
            var motorcyclesDTOs = new Motorcycles();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<MotorcycleDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }

        public override Task<Empty> UpdateMotorcycle(MotorcycleDTO request, ServerCallContext context)
        {
            var command = new UpdateMotorcycleCommand(_mapper.Map<Domain.Entities.Vehicles.Motorcycle>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        
        public override Task<Empty> DeleteMotorcycle(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteMotorcycleCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
