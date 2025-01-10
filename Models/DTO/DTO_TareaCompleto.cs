namespace ToDoList.Models.DTO
{
    public class DTO_TareaCompleto
    {
        public int IdTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int idEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
