using CarDealer.Domain.Entities.Vehicles;
using CarDealer.GrpcProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new CarDealer.GrpcProtos.Motorcycle.MotorcycleClient(channel);

            Console.WriteLine("Presione una tecla para crear una motocicleta");
            Console.ReadKey();
            var createResponse = client.CreateMotorcycle(new CreateMotorcycleRequest() 
            { 
                Brand = "Honda",
                Price = new Price()
                {
                    MoneyType = MoneyTypes.Euro,
                    Value = 5000
                },
                EnergySources = EnergySources.Gasoline
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create motorcycle");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener todas las motocicletas");
            Console.ReadKey();
            var getResponse = client.GetAllMotorcycles(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get price");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} motocicletas");
            }

            Console.WriteLine($"Presione una tecla para obtener la motocicleta con Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = client.GetMotorcycle(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get motorcycle");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la motocicleta {getByIdResponse.Motorcycle.Brand}");
            }

            Console.WriteLine("Presione una tecla para modificar la motocicleta");
            Console.ReadKey();
            createResponse.HasSideCar = !createResponse.HasSideCar;
            client.UpdateMotorcycle(createResponse);

            var updatedGetResponse = client.GetMotorcycle(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null && 
                updatedGetResponse.KindCase == NullableMotorcycleDTO.KindOneofCase.Motorcycle && 
                updatedGetResponse.Motorcycle.HasSideCar == createResponse.HasSideCar)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la motocicleta");
            Console.ReadKey();

            client.DeleteMotorcycle(new DeleteRequest() { Id = createResponse.Id});
            var deletedGetResponse = client.GetMotorcycle(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null || 
                deletedGetResponse.KindCase != NullableMotorcycleDTO.KindOneofCase.Motorcycle)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }


            channel.Dispose();

        }

    }
}