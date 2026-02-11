import { clsUsuario } from '../../entities/clsUsuario';

export interface IUsuarioRepository {
  getListaUsuarios(): Promise<clsUsuario[]>;
  getUsuarioPorId(idUsuario: number): Promise<clsUsuario>;
  getUsuarioPorNombre(nombre: string): Promise<clsUsuario>;
  crearUsuario(usuarioNuevo: clsUsuario): Promise<number>;
  actualizarUsuario(idUsuario: number, usuario: clsUsuario): Promise<number>;
  eliminarUsuario(idUsuario: number): Promise<number>;
}
