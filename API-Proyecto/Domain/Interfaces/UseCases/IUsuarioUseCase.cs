using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define las operaciones del caso de uso de Usuario.
    /// </summary>
    public interface IUsuarioUseCase
    {
        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        List<Usuario> GetListaUsuarios();

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado</returns>
        Usuario GetUsuarioPorId(int idUsuario);

        /// <summary>
        /// Valida las credenciales de un usuario mediante su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        Usuario ValidarCredenciales(string nombre);
    }
}