import { Injectable } from '@angular/core';
import { clsUsuario } from '../../domain/entities/clsUsuario';
import { IUsuarioRepository } from '../../domain/interfaces/repositories/IUsuarioRepository';
import { ApiConnection } from '../datasource/api/ApiConnection';

@Injectable({
  providedIn: 'root'
})
export class UsuarioRepository implements IUsuarioRepository {

  constructor(private api: ApiConnection) {}

  // Mapper
  private mapToEntity(data: any): clsUsuario {
    return new clsUsuario(
      data.idUsuario,
      data.nombre,
      data.email
    );
  }

  // GET listado usuarios
  async getListaUsuarios(): Promise<clsUsuario[]> {
    const response = await this.api.getUsuarios<any[]>();

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d => this.mapToEntity(d));
  }

  // GET usuario por id
  async getUsuarioPorId(idUsuario: number): Promise<clsUsuario> {
    const response = await this.api.getUsuarioPorId<any>(idUsuario);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return this.mapToEntity(response.data);
  }

  // GET usuario por nombre
  async getUsuarioPorNombre(nombre: string): Promise<clsUsuario> {
    const response = await this.api.validarUsuario<any>(nombre);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return this.mapToEntity(response.data);
  }
}
