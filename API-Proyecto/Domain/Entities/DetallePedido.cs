namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa el detalle de un pedido en el sistema ERP.
    /// Corresponde a la tabla DETALLE_PEDIDO de la base de datos.
    /// Clave primaria compuesta por IdPedido e IdProducto.
    /// </summary>
    public class DetallePedido
    {
        /// <summary>
        /// ID del pedido al que pertenece este detalle (FK a PEDIDO)
        /// </summary>
        public int IdPedido { get; set; }

        /// <summary>
        /// ID del producto incluido en el pedido (FK a PRODUCTO)
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Cantidad de unidades del producto
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario del producto en este pedido
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Constructor de la entidad DetallePedido.
        /// </summary>
        public DetallePedido()
        {
        }

        /// <summary>
        /// Constructor de la entidad DetallePedido con parámetros.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad de unidades</param>
        /// <param name="precioUnitario">Precio unitario del producto</param>
        public DetallePedido(int idPedido, int idProducto, int cantidad, decimal precioUnitario)
        {
            IdPedido = idPedido;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}