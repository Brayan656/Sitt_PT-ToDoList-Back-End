using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoList.Models.DB;
using ToDoList.Models.DTO;
using ToDoList.Repository.Interface;

namespace ToDoList.Repository.Repository
{
    public class TareasRepository : ITareasRepository
    {
        private readonly ToDoContext _db;
        public TareasRepository(ToDoContext db)
        {
            _db = db;
        }

        #region "Create"
        public async Task<int> add(DTO_Tarea task)
        {
            Tarea t = new Tarea();

            t.Titulo = task.Titulo;
            t.FechaCreacion = task.FechaCreacion == null ? DateTime.Now : task.FechaCreacion;
            t.Descripcion = task.Descripcion;
            t.idEstado = task.idEstado;

            await _db.Tareas.AddAsync(t);

            return await save();
        }
        #endregion

        #region "Read"
        public async Task<List<Tarea>> GetAll()
        {
            return await _db.Tareas.ToListAsync();
        }

        public async Task<Tarea> GetById(int id)
        {
            return await _db.Tareas.FirstOrDefaultAsync(x=>x.IdTarea==id);
        }

        public async Task<List<Tarea>> GetAllState(int estado)
        {
            return await _db.Tareas.Where(x => x.idEstado == estado).ToListAsync();
        }
        #endregion

        #region "Update"
        public async Task<int> Update(Tarea task)
        {
            var existe= await _db.Tareas.AnyAsync(x=>x.IdTarea == task.IdTarea);
            if (!existe)
                return -1;
            _db.Tareas.Update(task);
            return _db.SaveChanges();
        }
        #endregion

        #region "Delete"
        public async Task<int> Delete(int id)
        {
            var existe = await _db.Tareas.FirstOrDefaultAsync(x => x.IdTarea == id);
            if (existe==null)
                return -1;
            _db.Tareas.Remove(existe);
            return await save();
        }
        #endregion

        public async Task<int> save()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
