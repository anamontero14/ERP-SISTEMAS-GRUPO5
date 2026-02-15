import { clsUsuario } from '../../entities/clsUsuario';

export interface IUsuarioRepository {
  getListaUsuarios(): Promise<clsUsuario[]>;
  getUsuarioPorId(idUsuario: number): Promise<clsUsuario>;
  getUsuarioPorNombre(nombre: string): Promise<clsUsuario>;
}
