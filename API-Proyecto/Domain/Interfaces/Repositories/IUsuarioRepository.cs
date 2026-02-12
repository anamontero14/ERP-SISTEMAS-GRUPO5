using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones del repositorio de Usuario.
    /// </summary>
    public interface IUsuarioRepository
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
        /// <returns>Usuario encontrado o null si no existe</returns>
        Usuario? GetUsuarioPorId(int idUsuario);

        /// <summary>
        /// Obtiene un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a buscar</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        Usuario? GetUsuarioPorNombre(string nombre);
    }
}