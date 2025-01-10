namespace ToDoList.Models.DB
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int idEstado { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
