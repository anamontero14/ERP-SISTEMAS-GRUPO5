export interface ApiResponse<T> {
  success: boolean;
  statusCode: number;
  message: string;
  data?: T;
}

const BASE_URL = "https://api-proyectogruposinco-cqazb6ebhubmeqd0.francecentral-01.azurewebsites.net/api/";

export class ApiConnection {

  private static async request<T>(
    endpoint: string,
    method: string = "GET",
    body?: any
  ): Promise<ApiResponse<T>> {

    try {
      const response = await fetch(`${BASE_URL}/${endpoint}`, {
        method,
        headers: {
          "Content-Type": "application/json",
        },
        body: body ? JSON.stringify(body) : undefined,
      });

      let data: T | undefined;

      try {
        data = await response.json();
      } catch {
        data = undefined;
      }

      return {
        success: response.ok,
        statusCode: response.status,
        message: response.ok
          ? "Operación exitosa"
          : `Error HTTP ${response.status}`,
        data,
      };

    } catch (error: any) {
      return {
        success: false,
        statusCode: 500,
        message: error.message || "Error de conexión con el servidor",
      };
    }
  }

  static getUsuarios<T>() {
    return this.request<T>("Usuario");
  }

  static getUsuarioPorId<T>(id: number) {
    return this.request<T>(`Usuario/${id}`);
  }

  static validarUsuario<T>(nombre: string) {
    return this.request<T>(`Usuario/validar/${nombre}`);
  }

  static getProductos<T>() {
    return this.request<T>("Producto");
  }

  static getProductoPorId<T>(id: number) {
    return this.request<T>(`Producto/${id}`);
  }

  static getProveedores<T>() {
    return this.request<T>("Proveedor");
  }

  static getProveedorPorId<T>(id: number) {
    return this.request<T>(`Proveedor/${id}`);
  }

  static getPedidos<T>() {
    return this.request<T>("Pedido");
  }

  static getPedidoPorId<T>(id: number) {
    return this.request<T>(`Pedido/${id}`);
  }

  static getPedidosPorUsuario<T>(idUsuario: number) {
    return this.request<T>(`Pedido/usuario/${idUsuario}`);
  }

  static crearPedido<T>(pedido: any) {
    return this.request<T>("Pedido", "POST", pedido);
  }

  static actualizarPedido<T>(id: number, pedido: any) {
    return this.request<T>(`Pedido/${id}`, "PATCH", pedido);
  }

  static eliminarPedido<T>(id: number) {
    return this.request<T>(`Pedido/${id}`, "DELETE");
  }

  static getDetallesPedido<T>(idPedido: number) {
    return this.request<T>(`DetallesPedido/pedido/${idPedido}`);
  }

  static crearDetallePedido<T>(detalle: any) {
    return this.request<T>("DetallesPedido", "POST", detalle);
  }

  static actualizarDetallePedido<T>(
    idPedido: number,
    idProducto: number,
    detalle: any
  ) {
    return this.request<T>(
      `DetallesPedido/${idPedido}/${idProducto}`,
      "PATCH",
      detalle
    );
  }
}