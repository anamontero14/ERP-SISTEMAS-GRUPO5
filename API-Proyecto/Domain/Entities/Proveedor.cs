namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un proveedor en el sistema ERP.
    /// Corresponde a la tabla PROVEEDOR de la base de datos.
    /// </summary>
    public class Proveedor
    {
        // Identificador único del proveedor (autogenerado en BBDD)
        private int idProveedor;

        // CIF del proveedor 
        private string cifProveedor;

        // Nombre del proveedor 
        private string nombreProveedor;
        // Teléfono del proveedor 
        private string telefonoProveedor;

        // Email del proveedor 
        private string emailProveedor;

        // Dirección del proveedor 
        private string direccionProveedor;

        /// <summary>
        /// Constructor de la entidad Proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <param name="cifProveedor">CIF del proveedor</param>
        /// <param name="nombreProveedor">Nombre del proveedor</param>
        /// <param name="telefonoProveedor">Teléfono del proveedor</param>
        /// <param name="emailProveedor">Email del proveedor</param>
        /// <param name="direccionProveedor">Dirección del proveedor</param>
        public Proveedor(int idProveedor, string cifProveedor, string nombreProveedor,
            string telefonoProveedor, string emailProveedor, string direccionProveedor)
        {
            this.idProveedor = idProveedor;
            this.cifProveedor = cifProveedor;
            this.nombreProveedor = nombreProveedor;
            this.telefonoProveedor = telefonoProveedor;
            this.emailProveedor = emailProveedor;
            this.direccionProveedor = direccionProveedor;
        }

        // Getters públicos

        /// <summary>
        /// Obtiene el ID del proveedor.
        /// </summary>
        /// <returns>ID del proveedor</returns>
        public int getIdProveedor() { return idProveedor; }

        /// <summary>
        /// Obtiene el CIF del proveedor.
        /// </summary>
        /// <returns>CIF del proveedor</returns>
        public string getCifProveedor() { return cifProveedor; }

        /// <summary>
        /// Obtiene el nombre del proveedor.
        /// </summary>
        /// <returns>Nombre del proveedor</returns>
        public string getNombreProveedor() { return nombreProveedor; }

        /// <summary>
        /// Obtiene el teléfono del proveedor.
        /// </summary>
        /// <returns>Teléfono del proveedor</returns>
        public string getTelefonoProveedor() { return telefonoProveedor; }

        /// <summary>
        /// Obtiene el email del proveedor.
        /// </summary>
        /// <returns>Email del proveedor</returns>
        public string getEmailProveedor() { return emailProveedor; }

        /// <summary>
        /// Obtiene la dirección del proveedor.
        /// </summary>
        /// <returns>Dirección del proveedor</returns>
        public string getDireccionProveedor() { return direccionProveedor; }

        // Setters públicos (no incluye idProveedor porque es solo lectura)

        /// <summary>
        /// Establece el CIF del proveedor.
        /// </summary>
        /// <param name="cifProveedor">Nuevo CIF del proveedor</param>
        public void setCifProveedor(string cifProveedor) { this.cifProveedor = cifProveedor; }

        /// <summary>
        /// Establece el nombre del proveedor.
        /// </summary>
        /// <param name="nombreProveedor">Nuevo nombre del proveedor</param>
        public void setNombreProveedor(string nombreProveedor) { this.nombreProveedor = nombreProveedor; }

        /// <summary>
        /// Establece el teléfono del proveedor.
        /// </summary>
        /// <param name="telefonoProveedor">Nuevo teléfono del proveedor</param>
        public void setTelefonoProveedor(string telefonoProveedor) { this.telefonoProveedor = telefonoProveedor; }

        /// <summary>
        /// Establece el email del proveedor.
        /// </summary>
        /// <param name="emailProveedor">Nuevo email del proveedor</param>
        public void setEmailProveedor(string emailProveedor) { this.emailProveedor = emailProveedor; }

        /// <summary>
        /// Establece la dirección del proveedor.
        /// </summary>
        /// <param name="direccionProveedor">Nueva dirección del proveedor</param>
        public void setDireccionProveedor(string direccionProveedor) { this.direccionProveedor = direccionProveedor; }

    }
}