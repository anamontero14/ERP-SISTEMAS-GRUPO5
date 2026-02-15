namespace Domain.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public bool Archivado { get; set; }

        public Pedido()
        {
            FechaPedido = DateTime.MinValue;
        }

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
