using Core.Interfaces.Servicios;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IServicioUsuario _service;

        public UsuarioController(IServicioUsuario service)
        {
            _service = service;
        }
        /// <summary>
        /// Obtener a usuarios
        /// </summary>
        /// <returns>a lista de usuarios</returns>
        [ProducesResponseType(typeof(IList<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult response;
            try
            {
                var result = await _service.GetAllAsync();
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <returns>Usuario agregado</returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([Required, FromBody] Usuario request)
        {
            IActionResult response;
            try
            {
                var result = await _service.AddAsync(request);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <returns>Usuario borrado</returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([Required, FromBody] Usuario request)
        {
            IActionResult response;
            try
            {
                var result = await _service.DeleteAsync(request);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex.Message);
            }
            return response;
        }


        /// <summary>
        /// Actualiza al usuario
        /// </summary>
        /// <returns>Usuario actualizado</returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([Required, FromBody] Usuario request)
        {
            IActionResult response;
            try
            {
                var result = await _service.UpdateAsync(request);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Busca usuario
        /// </summary>
        /// <returns>lista de usuarios</returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]/{request}")]
        public async Task<IActionResult> Search([ FromRoute] string request="")
        {
            IActionResult response;
            try
            {
                var result = await _service.SearchAsync(request);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex.Message);
            }
            return response;
        }
    }
}
