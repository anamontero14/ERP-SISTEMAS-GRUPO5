using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de usuarios.
    /// Incluye funcionalidades de autenticación y validación de credenciales.
    /// </summary>
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor del caso de uso Usuario.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio de usuarios</param>
        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
        public List<Usuario> GetListaUsuarios()
        {
            return _usuarioRepository.GetListaUsuarios();
        }

        /// <summary>
        /// Obtiene un usuario específico por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado</returns>
        public Usuario GetUsuarioPorId(int idUsuario)
        {
            return _usuarioRepository.GetUsuarioPorId(idUsuario);
        }

        /// <summary>
        /// Valida las credenciales de un usuario mediante su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        public Usuario ValidarCredenciales(string nombre)
        {
            return _usuarioRepository.GetUsuarioPorNombre(nombre);
        }
    }
}