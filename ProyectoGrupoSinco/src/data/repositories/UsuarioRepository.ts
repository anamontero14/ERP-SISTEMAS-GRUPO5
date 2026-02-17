import { clsUsuario } from '../../domain/entities/clsUsuario';
import { IUsuarioRepository } from '../../domain/interfaces/repositories/IUsuarioRepository';

export class UsuarioRepository implements IUsuarioRepository {
  
    // Mock de Users
    private readonly usuariosMock: clsUsuario[] = [
        new clsUsuario(1, 'Alex Marin', 'alex@example.com'),
        new clsUsuario(2, 'Beatriz Lopez', 'beatriz@example.com')
    ];

    // GetListado User
    async getListaUsuarios(): Promise<clsUsuario[]> {
        return new Promise((resolve) => {
        setTimeout(() => {
            resolve(this.usuariosMock);
            }, 100);
        });
    }

    // GetPorId User
    async getUsuarioPorId(idUsuario: number): Promise<clsUsuario> {
        const usuario = this.usuariosMock.find(u => u.IdUsuario === idUsuario);
        if (!usuario) {
            throw new Error(`Usuario con id ${idUsuario} no encontrado`);
        }
        return Promise.resolve(usuario);
    }

    // GetPorNombre User
    async getUsuarioPorNombre(nombre: string): Promise<clsUsuario> {
        const usuario = this.usuariosMock.find(
        u => u.Nombre.toLowerCase().includes(nombre.toLowerCase())
        );
        if (!usuario) {
            throw new Error(`Usuario con nombre ${nombre} no encontrado`);
        }
        return Promise.resolve(usuario);
    }
}