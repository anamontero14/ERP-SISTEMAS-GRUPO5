namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un proveedor en el sistema ERP.
    /// Corresponde a la tabla PROVEEDOR de la base de datos.
    /// </summary>
    public class Proveedor
    {
        /// <summary>
        /// Identificador único del proveedor (autogenerado en BBDD)
        /// </summary>
        public int IdProveedor { get; set; }

        /// <summary>
        /// CIF del proveedor
        /// </summary>
        public string CifProveedor { get; set; }

        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        public string NombreProveedor { get; set; }

        /// <summary>
        /// Teléfono del proveedor
        /// </summary>
        public string TelefonoProveedor { get; set; }

        /// <summary>
        /// Email del proveedor
        /// </summary>
        public string EmailProveedor { get; set; }

        /// <summary>
        /// Dirección del proveedor
        /// </summary>
        public string DireccionProveedor { get; set; }

        /// <summary>
        /// Constructor de la entidad Proveedor.
        /// </summary>
        public Proveedor()
        {
        }

        /// <summary>
        /// Constructor de la entidad Proveedor con parámetros.
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
            IdProveedor = idProveedor;
            CifProveedor = cifProveedor;
            NombreProveedor = nombreProveedor;
            TelefonoProveedor = telefonoProveedor;
            EmailProveedor = emailProveedor;
            DireccionProveedor = direccionProveedor;
        }
    }
}