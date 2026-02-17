import { inject, injectable } from "inversify";
import { clsProveedor } from "../../domain/entities/clsProveedor";
import { IProveedorRepository } from "../../domain/interfaces/repositories/IProveedorRepository";
import { ApiConnection } from "../datasource/api/ApiConnection";
import { TYPES } from "../../di/types";

@injectable()
export class ProveedorRepository implements IProveedorRepository {

  constructor(
    @inject(TYPES.ApiConnection)
    private api: ApiConnection
  ) {}

  // Mapper
  private mapToEntity(data: any): clsProveedor {
    return new clsProveedor(
      data.idProveedor,
      data.cifProveedor,
      data.nombreProveedor,
      data.telefonoProveedor,
      data.emailProveedor,
      data.direccionProveedor
    );
  }

  // GET listado proveedores
  async getListaProveedores(): Promise<clsProveedor[]> {
    const response = await this.api.getProveedores<any[]>();

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d => this.mapToEntity(d));
  }

  // GET proveedor por id
  async getProveedorPorId(idProveedor: number): Promise<clsProveedor> {
    const response = await this.api.getProveedorPorId<any>(idProveedor);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return this.mapToEntity(response.data);
  }
}
