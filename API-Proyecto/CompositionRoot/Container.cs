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
    /// <summary>
    /// Clase estática que configura la inyección de dependencias del proyecto.
    /// Registra las implementaciones concretas de los repositorios y casos de uso
    /// para que el framework las inyecte automáticamente donde se necesiten.
    /// </summary>
    public static class Container
    {
        /// <summary>
        /// Método de extensión que registra todos los servicios de la aplicación
        /// en el contenedor de inyección de dependencias.
        /// </summary>
        /// <param name="services">Colección de servicios del framework</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <returns>Colección de servicios con los registros añadidos</returns>
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Registro de repositorios: enlaza cada interfaz con su implementación Azure
            services.AddScoped<IDetallesPedidoRepository, DetallesPedidoRepositoryAzure>();
            services.AddScoped<IPedidoRepository, PedidoRepositoryAzure>();
            services.AddScoped<IProductoRepository, ProductoRepositoryAzure>();
            services.AddScoped<IProveedorRepository, ProveedorRepositoryAzure>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryAzure>();

            // Registro de casos de uso: enlaza cada interfaz con su implementación
            services.AddScoped<IDetallesPedidoUseCase, DetallePedidoUseCase>();
            services.AddScoped<IPedidoUseCase, PedidoUseCase>();
            services.AddScoped<IProductoUseCase, ProductoUseCase>();
            services.AddScoped<IProveedorUseCase, ProveedorUseCase>();
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();

            return services;
        }
    }
}
