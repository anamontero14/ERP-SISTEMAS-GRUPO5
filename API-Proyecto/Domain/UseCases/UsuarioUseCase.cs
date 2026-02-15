using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetListaUsuarios()
        {
            return _usuarioRepository.GetListaUsuarios();
        }

        public Usuario GetUsuarioPorId(int idUsuario)
        {
            return _usuarioRepository.GetUsuarioPorId(idUsuario);
        }

        public Usuario ValidarCredenciales(string nombre)
        {
            return _usuarioRepository.GetUsuarioPorNombre(nombre);
        }
    }
}