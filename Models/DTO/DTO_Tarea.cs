using ToDoList.Models.DB;

namespace ToDoList.Models.DTO
{
    public class DTO_Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int idEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
