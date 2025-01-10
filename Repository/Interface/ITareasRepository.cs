using ToDoList.Models.DB;
using ToDoList.Models.DTO;

namespace ToDoList.Repository.Interface
{
    public interface ITareasRepository
    {
        #region "Create"
        Task<int> add(DTO_Tarea task);
        #endregion

        #region "Read"
        Task<List<Tarea>> GetAll();
        Task<List<Tarea>> GetAllState(int estado);
        Task<Tarea> GetById(int id);
        #endregion
        
        #region "update"
        Task<int> Update(Tarea task);
        #endregion

        #region "Delete"
        Task<int> Delete(int id);
        #endregion


    }
}
