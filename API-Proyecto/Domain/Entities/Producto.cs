namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un producto en el sistema ERP.
    /// Corresponde a la tabla PRODUCTO de la base de datos.
    /// </summary>
    public class Producto
    {
        // Identificador único del producto (autogenerado en BBDD)
        private int idProducto;

        // Nombre del producto
        private string nombreProducto;

        // Descripción del producto
        private string descripcionProducto;

        // Precio del producto
        private decimal precioProducto;

        // Stock disponible del producto
        private int stockProducto;

        // Procedencia/origen del producto
        private string procedenciaProducto;

        /// <summary>
        /// Constructor de la entidad Producto.
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
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.descripcionProducto = descripcionProducto;
            this.precioProducto = precioProducto;
            this.stockProducto = stockProducto;
            this.procedenciaProducto = procedenciaProducto;
        }

        // Getters públicos

        /// <summary>
        /// Obtiene el ID del producto.
        /// </summary>
        /// <returns>ID del producto</returns>
        public int getIdProducto() { return idProducto; }

        /// <summary>
        /// Obtiene el nombre del producto.
        /// </summary>
        /// <returns>Nombre del producto</returns>
        public string getNombreProducto() { return nombreProducto; }

        /// <summary>
        /// Obtiene la descripción del producto.
        /// </summary>
        /// <returns>Descripción del producto</returns>
        public string getDescripcionProducto() { return descripcionProducto; }

        /// <summary>
        /// Obtiene el precio del producto.
        /// </summary>
        /// <returns>Precio del producto</returns>
        public decimal getPrecioProducto() { return precioProducto; }

        /// <summary>
        /// Obtiene el stock del producto.
        /// </summary>
        /// <returns>Stock disponible</returns>
        public int getStockProducto() { return stockProducto; }

        /// <summary>
        /// Obtiene la procedencia del producto.
        /// </summary>
        /// <returns>Procedencia del producto</returns>
        public string getProcedenciaProducto() { return procedenciaProducto; }

        // Setters públicos (no incluye idProducto porque es solo lectura)

        /// <summary>
        /// Establece el nombre del producto.
        /// </summary>
        /// <param name="nombreProducto">Nuevo nombre del producto</param>
        public void setNombreProducto(string nombreProducto) { this.nombreProducto = nombreProducto; }

        /// <summary>
        /// Establece la descripción del producto.
        /// </summary>
        /// <param name="descripcionProducto">Nueva descripción del producto</param>
        public void setDescripcionProducto(string descripcionProducto) { this.descripcionProducto = descripcionProducto; }

        /// <summary>
        /// Establece el precio del producto.
        /// </summary>
        /// <param name="precioProducto">Nuevo precio del producto</param>
        public void setPrecioProducto(decimal precioProducto) { this.precioProducto = precioProducto; }

        /// <summary>
        /// Establece el stock del producto.
        /// </summary>
        /// <param name="stockProducto">Nuevo stock disponible</param>
        public void setStockProducto(int stockProducto) { this.stockProducto = stockProducto; }

        /// <summary>
        /// Establece la procedencia del producto.
        /// </summary>
        /// <param name="procedenciaProducto">Nueva procedencia del producto</param>
        public void setProcedenciaProducto(string procedenciaProducto) { this.procedenciaProducto = procedenciaProducto; }

    }
}