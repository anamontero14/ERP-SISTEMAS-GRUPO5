import { injectable } from "inversify";

export interface ApiResponse<T> {
  success: boolean;
  statusCode: number;
  message: string;
  data?: T;
}

const BASE_URL = "https://api-proyectogruposinco-cqazb6ebhubmeqd0.francecentral-01.azurewebsites.net/api/";

@injectable()
export class ApiConnection {

  private async request<T>(
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

  getUsuarios<T>() {
    return this.request<T>("Usuario");
  }

  getUsuarioPorId<T>(id: number) {
    return this.request<T>(`Usuario/${id}`);
  }

  validarUsuario<T>(nombre: string) {
    return this.request<T>(`Usuario/validar/${nombre}`);
  }

  getProductos<T>() {
    return this.request<T>("Producto");
  }

  getProductoPorId<T>(id: number) {
    return this.request<T>(`Producto/${id}`);
  }

  getProveedores<T>() {
    return this.request<T>("Proveedor");
  }

  getProveedorPorId<T>(id: number) {
    return this.request<T>(`Proveedor/${id}`);
  }

  getPedidos<T>() {
    return this.request<T>("Pedido");
  }

  getPedidoPorId<T>(id: number) {
    return this.request<T>(`Pedido/${id}`);
  }

  getPedidosPorUsuario<T>(idUsuario: number) {
    return this.request<T>(`Pedido/usuario/${idUsuario}`);
  }

  crearPedido<T>(pedido: any) {
    return this.request<T>("Pedido", "POST", pedido);
  }

  actualizarPedido<T>(id: number, pedido: any) {
    return this.request<T>(`Pedido/${id}`, "PATCH", pedido);
  }

  eliminarPedido<T>(id: number) {
    return this.request<T>(`Pedido/${id}`, "DELETE");
  }

  getDetallesPedido<T>(idPedido: number) {
    return this.request<T>(`DetallesPedido/pedido/${idPedido}`);
  }

  crearDetallePedido<T>(detalle: any) {
    return this.request<T>("DetallesPedido", "POST", detalle);
  }

  actualizarDetallePedido<T>(
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
