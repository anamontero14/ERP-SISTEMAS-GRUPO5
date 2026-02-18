using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar usuarios.
    /// Solo permite operaciones de lectura (GET).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Caso de uso de usuario inyectado por dependencias
        private readonly IUsuarioUseCase _usuarioUseCase;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary>
        /// <param name="usuarioUseCase">Caso de uso de usuario</param>
        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        // GET: api/Usuario
        [HttpGet]
        public IActionResult GetListaUsuarios()
        {
            List<Usuario> usuarios = _usuarioUseCase.GetListaUsuarios();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado o 404 si no existe</returns>
        // GET: api/Usuario/5
        [HttpGet("{idUsuario}")]
        public IActionResult GetUsuarioPorId(int idUsuario)
        {
            Usuario usuario = _usuarioUseCase.GetUsuarioPorId(idUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        /// <summary>
        /// Valida las credenciales de un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a validar</param>
        /// <returns>Usuario encontrado o 404 si no existe</returns>
        // GET: api/Usuario/validar/Juan
        [HttpGet("validar/{nombre}")]
        public IActionResult ValidarCredenciales(string nombre)
        {
            Usuario usuario = _usuarioUseCase.ValidarCredenciales(nombre);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
    }
}