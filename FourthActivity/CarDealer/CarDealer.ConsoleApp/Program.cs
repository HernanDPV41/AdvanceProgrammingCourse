using CarDealer.DataAccess.Concrete;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
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
            if(channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new CarDealer.GrpcProtos.Price.PriceClient(channel);

            Console.WriteLine("Presione una tecla para crear un precio");
            Console.ReadKey();
            var createResponse = client.CreatePrice(new CreatePriceRequest() { Value = 5, MoneyType = MoneyTypes.Mlc });
            if (createResponse is null)
            {
                Console.WriteLine("Cannot create price");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener el precio");
            //Console.ReadKey();
            var getResponse = client.GetPrice(new GetRequest() { Id = 1 });
            if (getResponse.Price is null)
            {
                Console.WriteLine("Cannot get price");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse.Price.Value} {getResponse.Price.MoneyType.ToString() }");

            }

            Console.WriteLine("Presione una tecla para modificar el precio");
            Console.ReadKey();
            createResponse.Value = 20;
            client.UpdatePrice(createResponse);

            var updatedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null && updatedGetResponse.KindCase == NullablePriceDTO.KindOneofCase.Price && updatedGetResponse.Price.Value == 20)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar el precio");
            Console.ReadKey();

            client.DeletePrice(createResponse);
            var deletedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null || deletedGetResponse.KindCase != NullablePriceDTO.KindOneofCase.Price)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }


            channel.Dispose();

        }

    }
}