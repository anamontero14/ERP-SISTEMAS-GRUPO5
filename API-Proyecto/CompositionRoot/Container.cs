using Data.Repositories.AzureRepositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace CompositionRoot
{
    public static class Container
    {
        //hay que instalar los paquetes nugget
        //addcomposition root 
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //registra esos repositorios con su clase
            services.AddScoped<IDetallesPedidoRepository, DetallesPedidoRepositoryAzure>();
            services.AddScoped<IPedidoRepository, PedidoRepositoryAzure>();
            services.AddScoped<IProductoRepository, ProductoRepositoryAzure>();
            services.AddScoped<IProveedorRepository, ProveedorRepositoryAzure>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryAzure>();
            services.AddScoped<IDetallesPedidoUseCase, DetallePedidoUseCase>();
            services.AddScoped<IPedidoUseCase, PedidoUseCase>();
            services.AddScoped<IProductoUseCase, ProductoUseCase>();
            services.AddScoped<IProveedorUseCase, ProveedorUseCase>();
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();

            return services;
        }
    }
}
