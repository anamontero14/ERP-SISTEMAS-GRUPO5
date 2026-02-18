/*using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio de Usuario con datos mock en memoria.
    /// Implementa la interfaz IUsuarioRepository.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        // Lista estática en memoria que simula la tabla USUARIO
        private static List<Usuario> listaUsuarios = new List<Usuario>
        {
            new Usuario(1, "Juan", "juan@email.com"),
            new Usuario(2, "María", "maria@email.com"),
            new Usuario(3, "Carlos", "carlos@email.com"),
            new Usuario(4, "Ana", "ana@email.com"),
            new Usuario(5, "Pedro", "pedro@email.com")
        };

        // Contador para generar IDs automáticamente
        private static int contadorId = 6;

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Usuario> GetListaUsuarios()
        {
            return listaUsuarios;
        }

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        public Usuario GetUsuarioPorId(int idUsuario)
        {
            return listaUsuarios.FirstOrDefault(u => u.getIdUsuario() == idUsuario);
        }

        /// <summary>
        /// Obtiene un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a buscar</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        public Usuario GetUsuarioPorNombre(string nombre)
        {
            return listaUsuarios.FirstOrDefault(u => u.getNombre() == nombre);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuarioNuevo">Usuario a crear</param>
        /// <returns>1 si se creó correctamente, 0 en caso contrario</returns>
        public int CrearUsuario(Usuario usuarioNuevo)
        {
            Usuario usuario = new Usuario(
                contadorId++,
                usuarioNuevo.getNombre(),
                usuarioNuevo.getEmail()
            );
            listaUsuarios.Add(usuario);
            return 1;
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a actualizar</param>
        /// <param name="usuario">Datos actualizados del usuario</param>
        /// <returns>1 si se actualizó correctamente, 0 si no se encontró</returns>
        public int ActualizarUsuario(int idUsuario, Usuario usuario)
        {
            Usuario usuarioExistente = listaUsuarios.FirstOrDefault(u => u.getIdUsuario() == idUsuario);
            if (usuarioExistente == null) return 0;

            usuarioExistente.setNombre(usuario.getNombre());
            usuarioExistente.setEmail(usuario.getEmail());
            return 1;
        }

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar</param>
        /// <returns>1 si se eliminó correctamente, 0 si no se encontró</returns>
        public int EliminarUsuario(int idUsuario)
        {
            Usuario usuario = listaUsuarios.FirstOrDefault(u => u.getIdUsuario() == idUsuario);
            if (usuario == null) return 0;

            listaUsuarios.Remove(usuario);
            return 1;
        }
    }
}
*/