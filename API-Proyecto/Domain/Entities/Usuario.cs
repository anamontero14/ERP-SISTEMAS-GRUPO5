namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un usuario en el sistema ERP.
    /// Corresponde a la tabla USUARIO de la base de datos.
    /// </summary>
    public class Usuario
    {
        // Identificador único del usuario (autogenerado en BBDD)
        private int idUsuario;

        // Nombre del usuario (único, máximo 50 caracteres)
        private string nombre;

        // Email del usuario (máximo 50 caracteres)
        private string email;

        /// <summary>
        /// Constructor de la entidad Usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="email">Email del usuario</param>
        public Usuario(int idUsuario, string nombre, string email)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.email = email;
        }

        // Getters públicos

        /// <summary>
        /// Obtiene el ID del usuario.
        /// </summary>
        /// <returns>ID del usuario</returns>
        public int getIdUsuario() { return idUsuario; }

        /// <summary>
        /// Obtiene el nombre del usuario.
        /// </summary>
        /// <returns>Nombre del usuario</returns>
        public string getNombre() { return nombre; }

        /// <summary>
        /// Obtiene el email del usuario.
        /// </summary>
        /// <returns>Email del usuario</returns>
        public string getEmail() { return email; }

        // Setters públicos (no incluye idUsuario porque es solo lectura)

        /// <summary>
        /// Establece el nombre del usuario.
        /// </summary>
        /// <param name="nombre">Nuevo nombre del usuario</param>
        public void setNombre(string nombre) { this.nombre = nombre; }

        /// <summary>
        /// Establece el email del usuario.
        /// </summary>
        /// <param name="email">Nuevo email del usuario</param>
        public void setEmail(string email) { this.email = email; }

    }
}