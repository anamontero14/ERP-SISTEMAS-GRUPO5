namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un usuario en el sistema ERP.
    /// Corresponde a la tabla USUARIO de la base de datos.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario (autogenerado en BBDD)
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre del usuario (único, máximo 50 caracteres)
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Email del usuario (máximo 50 caracteres)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Constructor de la entidad Usuario.
        /// </summary>
        public Usuario()
        {
        }

        /// <summary>
        /// Constructor de la entidad Usuario con parámetros.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="email">Email del usuario</param>
        public Usuario(int idUsuario, string nombre, string email)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Email = email;
        }
    }
}