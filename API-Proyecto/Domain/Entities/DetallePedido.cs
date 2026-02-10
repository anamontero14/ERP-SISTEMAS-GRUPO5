namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa el detalle de un pedido en el sistema ERP.
    /// Corresponde a la tabla DETALLE_PEDIDO de la base de datos.
    /// Clave primaria compuesta por idPedido e idProducto.
    /// </summary>
    public class DetallePedido
    {
        // ID del pedido al que pertenece este detalle (FK a PEDIDO)
        private int idPedido;

        // ID del producto incluido en el pedido (FK a PRODUCTO)
        private int idProducto;

        // Cantidad de unidades del producto
        private int cantidad;

        // Precio unitario del producto en este pedido
        private decimal precioUnitario;

        /// <summary>
        /// Constructor de la entidad DetallePedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad de unidades</param>
        /// <param name="precioUnitario">Precio unitario del producto</param>
        public DetallePedido(int idPedido, int idProducto,
            int cantidad, decimal precioUnitario)
        {
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }

        // Getters públicos

        /// <summary>
        /// Obtiene el ID del pedido.
        /// </summary>
        /// <returns>ID del pedido</returns>
        public int getIdPedido() { return idPedido; }

        /// <summary>
        /// Obtiene el ID del producto.
        /// </summary>
        /// <returns>ID del producto</returns>
        public int getIdProducto() { return idProducto; }

        /// <summary>
        /// Obtiene la cantidad de unidades.
        /// </summary>
        /// <returns>Cantidad de unidades</returns>
        public int getCantidad() { return cantidad; }

        /// <summary>
        /// Obtiene el precio unitario del producto.
        /// </summary>
        /// <returns>Precio unitario</returns>
        public decimal getPrecioUnitario() { return precioUnitario; }

        // Setters públicos

        /// <summary>
        /// Establece el ID del pedido.
        /// </summary>
        /// <param name="idPedido">Nuevo ID del pedido</param>
        public void setIdPedido(int idPedido) { this.idPedido = idPedido; }

        /// <summary>
        /// Establece el ID del producto.
        /// </summary>
        /// <param name="idProducto">Nuevo ID del producto</param>
        public void setIdProducto(int idProducto) { this.idProducto = idProducto; }

        /// <summary>
        /// Establece la cantidad de unidades.
        /// </summary>
        /// <param name="cantidad">Nueva cantidad de unidades</param>
        public void setCantidad(int cantidad) { this.cantidad = cantidad; }

        /// <summary>
        /// Establece el precio unitario del producto.
        /// </summary>
        /// <param name="precioUnitario">Nuevo precio unitario</param>
        public void setPrecioUnitario(decimal precioUnitario) { this.precioUnitario = precioUnitario; }

    }
}