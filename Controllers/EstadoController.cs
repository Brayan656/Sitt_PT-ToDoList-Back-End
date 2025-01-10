using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.Models.DB;
using ToDoList.Models.DTO;
using ToDoList.Models.Shared;
using ToDoList.Repository.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("Estado")]
    public class EstadoController : ControllerBase
    {
        private RespuestaAPI _respuestaAPI;
        private readonly IEstadosRepository _repo;
        public EstadoController(IEstadosRepository repo)
        {
            _respuestaAPI = new();
            _repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repo.GetAll();

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = lista;

            return Ok(_respuestaAPI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(string estado)
        {
            
            var agregar = await _repo.Add(estado);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.Created;
            _respuestaAPI.Result = agregar;

            return Created();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Estado e)
        {

            var agregar = await _repo.Update(e);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = agregar;

            return Ok();
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {

            var tarea = await _repo.Delete(Id);

            if (tarea == null)
            {
                _respuestaAPI.IsSuccess = false;
                _respuestaAPI.StatusCode = HttpStatusCode.NotFound;
                _respuestaAPI.ErrorMessage.Add("");
                _respuestaAPI.Result = null;
                return NotFound(_respuestaAPI);

            }
            else
            {

                var eliminar = await _repo.Delete(Id);
                _respuestaAPI.IsSuccess = true;
                _respuestaAPI.StatusCode = HttpStatusCode.OK;
                _respuestaAPI.Result = eliminar;

                return Ok(_respuestaAPI);
            }
        }
    }
}
