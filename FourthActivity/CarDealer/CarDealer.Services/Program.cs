using CarDealer.Application;
using CarDealer.Contracts;
using CarDealer.Contracts.Clients;
using CarDealer.Contracts.Orders;
using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Repositories.Clients;
using CarDealer.DataAccess.Repositories.Orders;
using CarDealer.DataAccess.Repositories.Vehicles;
using CarDealer.Services.Services;

namespace CarDealer.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration() 
            { 
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IVehicleRepository,VehicleRepository>();
            builder.Services.AddScoped<IClientRepository,ClientRepository>();
            builder.Services.AddScoped<IBuyOrderRepository,BuyOrderRepository>();

            
            //builder.Services.AddScoped<IPriceRepository, ApplicationRepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<MotorcycleService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}