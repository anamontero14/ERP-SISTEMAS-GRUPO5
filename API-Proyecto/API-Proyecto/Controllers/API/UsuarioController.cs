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
        /// <summary>
        /// Atributo que almacena el caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IUsuarioUseCase _usuarioUseCase;

        /// <summary>
        /// Inyección del caso de uso de usuarios
        /// </summary>
        /// <param name="usuarioUseCase">Caso de uso de usuario</param>
        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios llamando al caso de uso.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        // GET: api/Usuario
        [HttpGet]
        public IActionResult GetListaUsuarios()
        {
            IActionResult resultado;
            try
            {
                List<Usuario> usuarios = _usuarioUseCase.GetListaUsuarios();
                resultado = Ok(usuarios);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener la lista de usuarios: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene un usuario por su identificador llamando al caso de uso.
        /// Si no se encuentra el usuario, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado o 404 si no existe</returns>
        // GET: api/Usuario/5
        [HttpGet("{idUsuario}")]
        public IActionResult GetUsuarioPorId(int idUsuario)
        {
            IActionResult resultado;
            try
            {
                Usuario usuario = _usuarioUseCase.GetUsuarioPorId(idUsuario);
                resultado = usuario == null ? NotFound() : Ok(usuario);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener el usuario: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Valida las credenciales de un usuario buscándole por su nombre.
        /// Si no se encuentra el usuario, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a validar</param>
        /// <returns>Usuario encontrado o 404 si no existe</returns>
        // GET: api/Usuario/validar/Juan
        [HttpGet("validar/{nombre}")]
        public IActionResult ValidarCredenciales(string nombre)
        {
            IActionResult resultado;
            try
            {
                Usuario usuario = _usuarioUseCase.ValidarCredenciales(nombre);
                resultado = usuario == null ? NotFound() : Ok(usuario);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al validar las credenciales: {ex.Message}");
            }
            return resultado;
        }
    }
}