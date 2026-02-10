namespace Domain.Entities
{
    /// <summary>
    /// Entidad que representa un pedido en el sistema ERP.
    /// Corresponde a la tabla PEDIDO de la base de datos.
    /// </summary>
    public class Pedido
    {
        // Identificador único del pedido (autogenerado en BBDD)
        private int idPedido;

        // ID del usuario que realiza el pedido (FK a USUARIO)
        private int idUsuario;

        // ID del proveedor al que se le hace el pedido (FK a PROVEEDOR)
        private int idProveedor;

        // Fecha en la que se realizó el pedido
        private DateTime fechaPedido { get; set; }

        // Estado del pedido: 'pedido', 'enviado' o 'entregado'
        private string estado;

        // Observaciones adicionales del pedido
        private string observaciones;

        /// <summary>
        /// Constructor de la entidad Pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idUsuario">ID del usuario que realiza el pedido</param>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <param name="fechaPedido">Fecha del pedido</param>
        /// <param name="estado">Estado del pedido (pedido/enviado/entregado)</param>
        /// <param name="observaciones">Observaciones del pedido</param>
        public Pedido(int idPedido, int idUsuario, int idProveedor,
            DateTime fechaPedido, string estado, string observaciones)
        {
            this.idPedido = idPedido;
            this.idUsuario = idUsuario;
            this.idProveedor = idProveedor;
            this.fechaPedido = fechaPedido;
            this.estado = estado;
            this.observaciones = observaciones;
        }

        // Getters públicos

        /// <summary>
        /// Obtiene el ID del pedido.
        /// </summary>
        /// <returns>ID del pedido</returns>
        public int getIdPedido() { return idPedido; }

        /// <summary>
        /// Obtiene el ID del usuario del pedido.
        /// </summary>
        /// <returns>ID del usuario</returns>
        public int getIdUsuario() { return idUsuario; }

        /// <summary>
        /// Obtiene el ID del proveedor del pedido.
        /// </summary>
        /// <returns>ID del proveedor</returns>
        public int getIdProveedor() { return idProveedor; }

        /// <summary>
        /// Obtiene la fecha del pedido.
        /// </summary>
        /// <returns>Fecha del pedido</returns>
        public DateTime getFechaPedido() { return fechaPedido; }

        /// <summary>
        /// Obtiene el estado del pedido.
        /// </summary>
        /// <returns>Estado del pedido</returns>
        public string getEstado() { return estado; }

        /// <summary>
        /// Obtiene las observaciones del pedido.
        /// </summary>
        /// <returns>Observaciones del pedido</returns>
        public string getObservaciones() { return observaciones; }

        // Setters públicos (no incluye idPedido porque es solo lectura)

        /// <summary>
        /// Establece el ID del usuario del pedido.
        /// </summary>
        /// <param name="idUsuario">Nuevo ID del usuario</param>
        public void setIdUsuario(int idUsuario) { this.idUsuario = idUsuario; }

        /// <summary>
        /// Establece el ID del proveedor del pedido.
        /// </summary>
        /// <param name="idProveedor">Nuevo ID del proveedor</param>
        public void setIdProveedor(int idProveedor) { this.idProveedor = idProveedor; }

        /// <summary>
        /// Establece la fecha del pedido.
        /// </summary>
        /// <param name="fechaPedido">Nueva fecha del pedido</param>
        public void setFechaPedido(DateTime fechaPedido) { this.fechaPedido = fechaPedido; }

        /// <summary>
        /// Establece el estado del pedido.
        /// </summary>
        /// <param name="estado">Nuevo estado (pedido/enviado/entregado)</param>
        public void setEstado(string estado) { this.estado = estado; }

        /// <summary>
        /// Establece las observaciones del pedido.
        /// </summary>
        /// <param name="observaciones">Nuevas observaciones del pedido</param>
        public void setObservaciones(string observaciones) { this.observaciones = observaciones; }

    }
}