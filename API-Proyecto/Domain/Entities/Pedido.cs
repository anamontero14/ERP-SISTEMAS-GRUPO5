namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un pedido en el sistema ERP.
    /// Corresponde a la tabla PEDIDO de la base de datos.
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Identificador único del pedido (autogenerado en BBDD)
        /// </summary>
        public int IdPedido { get; set; }

        /// <summary>
        /// ID del usuario que realiza el pedido (FK a USUARIO)
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// ID del proveedor asociado al pedido (FK a PROVEEDOR)
        /// </summary>
        public int IdProveedor { get; set; }

        /// <summary>
        /// Fecha en la que se realizó el pedido
        /// </summary>
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Estado actual del pedido (pedido/enviado/entregado)
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Observaciones o notas adicionales sobre el pedido
        /// </summary>
        public string Observaciones { get; set; } = string.Empty;

        /// <summary>
        /// Indica si el pedido ha sido archivado
        /// </summary>
        public bool Archivado { get; set; }

        /// <summary>
        /// Constructor de la entidad Pedido.
        /// </summary>
        public Pedido()
        {
            FechaPedido = DateTime.MinValue;
        }

        /// <summary>
        /// Constructor de la entidad Pedido con parámetros.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <param name="fechaPedido">Fecha del pedido</param>
        /// <param name="estado">Estado del pedido</param>
        /// <param name="observaciones">Observaciones del pedido</param>
        /// <param name="archivado">Indicador de archivado</param>
        public Pedido(int idPedido, int idUsuario, int idProveedor,
            DateTime fechaPedido, string estado, string observaciones, bool archivado)
        {
            IdPedido = idPedido;
            IdUsuario = idUsuario;
            IdProveedor = idProveedor;
            FechaPedido = fechaPedido;
            Estado = estado ?? string.Empty;
            Observaciones = observaciones ?? string.Empty;
            Archivado = archivado;
        }
    }
}