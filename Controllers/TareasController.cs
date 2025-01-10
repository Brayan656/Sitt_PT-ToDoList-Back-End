using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.Models.DB;
using ToDoList.Models.DTO;
using ToDoList.Models.Shared;
using ToDoList.Repository.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("Tareas")]
    public class TareasController : ControllerBase
    {
        private RespuestaAPI _respuestaAPI;
        private readonly ITareasRepository _repo;
        public TareasController(ITareasRepository repo)
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

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var tarea = await _repo.GetById(id);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = tarea;

            return Ok(_respuestaAPI);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetByEstado(int id)
        {
            var lista = await _repo.GetAllState(id);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = lista;

            return Ok(_respuestaAPI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] DTO_TareaCreate tarea)
        {
            DTO_Tarea nueva = new DTO_Tarea();
            nueva.Titulo = tarea.Titulo;
            nueva.Descripcion = tarea.Descripcion;
            nueva.FechaCreacion = tarea.FechaCreacion;
            nueva.idEstado = 1;

            var agregar = await _repo.add(nueva);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = agregar;

            return Created();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] DTO_TareaCompleto tarea)
        {

            Tarea t=new Tarea();
            t.IdTarea=tarea.IdTarea;
            t.FechaCreacion=tarea.FechaCreacion;
            t.Titulo=tarea.Titulo;
            t.Descripcion=tarea.Descripcion;

            var agregar = await _repo.Update(t);

            _respuestaAPI.IsSuccess = true;
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.Result = agregar;

            return Ok();
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {

            var tarea = await _repo.GetById(Id);

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
                var eliminar= await _repo.Delete(Id);
                _respuestaAPI.IsSuccess = true;
                _respuestaAPI.StatusCode = HttpStatusCode.OK;
                _respuestaAPI.Result = eliminar;

                return Ok(_respuestaAPI);
            }
        }
    }
}
