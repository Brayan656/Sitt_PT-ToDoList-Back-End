using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTO
{
    public class DTO_TareaCreate
    {
        [Required(ErrorMessage = "Se necesita el titulo de la tarea")]
        public string Titulo { get; set; }
        public string Descripcion { get; set; } = "";
        public DateTime FechaCreacion { get; set; }=DateTime.Now;
    }
}
