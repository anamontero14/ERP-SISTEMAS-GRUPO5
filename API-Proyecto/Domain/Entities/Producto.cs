namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un producto en el sistema ERP.
    /// Corresponde a la tabla PRODUCTO de la base de datos.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto (autogenerado en BBDD)
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string NombreProducto { get; set; }

        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string DescripcionProducto { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal PrecioProducto { get; set; }

        /// <summary>
        /// Stock disponible del producto
        /// </summary>
        public int StockProducto { get; set; }

        /// <summary>
        /// Procedencia/origen del producto
        /// </summary>
        public string ProcedenciaProducto { get; set; }

        /// <summary>
        /// Constructor de la entidad Producto.
        /// </summary>
        public Producto()
        {
        }

        /// <summary>
        /// Constructor de la entidad Producto con parámetros.
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="nombreProducto">Nombre del producto</param>
        /// <param name="descripcionProducto">Descripción del producto</param>
        /// <param name="precioProducto">Precio del producto</param>
        /// <param name="stockProducto">Stock disponible</param>
        /// <param name="procedenciaProducto">Procedencia del producto</param>
        public Producto(int idProducto, string nombreProducto, string descripcionProducto,
            decimal precioProducto, int stockProducto, string procedenciaProducto)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            DescripcionProducto = descripcionProducto;
            PrecioProducto = precioProducto;
            StockProducto = stockProducto;
            ProcedenciaProducto = procedenciaProducto;
        }
    }
}