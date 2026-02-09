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
        /// <returns>Usuario encontrado</returns>
        Usuario GetUsuarioPorId(int idUsuario);

        /// <summary>
        /// Obtiene un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a buscar</param>
        /// <returns>Usuario encontrado</returns>
        Usuario GetUsuarioPorNombre(string nombre);

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuarioNuevo">Usuario a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearUsuario(Usuario usuarioNuevo);

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a actualizar</param>
        /// <param name="usuario">Datos actualizados del usuario</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarUsuario(int idUsuario, Usuario usuario);

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarUsuario(int idUsuario);
    }
}
