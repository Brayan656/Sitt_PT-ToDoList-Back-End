using ToDoList.Models.DB;

namespace ToDoList.Repository.Interface
{
    public interface IEstadosRepository
    {
        Task<List<Estado>> GetAll();
        Task<Estado> Add(string estado);
        Task<Estado> Update(Estado estado);
        Task<Estado> Delete(int id);
        
    }
}
