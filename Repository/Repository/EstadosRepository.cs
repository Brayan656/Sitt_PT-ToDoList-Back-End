using Microsoft.EntityFrameworkCore;
using ToDoList.Models.DB;
using ToDoList.Repository.Interface;

namespace ToDoList.Repository.Repository
{
    public class EstadosRepository : IEstadosRepository
    {
        private readonly ToDoContext _db;
        public EstadosRepository(ToDoContext db)
        {
            _db = db;
        }
        public async Task<Estado> Add(string estado)
        {
            Estado e = new Estado();
            e.estado=estado;
            await _db.Estados.AddAsync(e);
            var guardar = await save();
            if (guardar == 1)
            {
                return await _db.Estados.FirstOrDefaultAsync(x => x.estado == estado);
            }
            else return null;
        }

        public async Task<Estado> Delete(int id)
        {
            var estado = await _db.Estados.FirstOrDefaultAsync(x=>x.IdEstado==id);
            if (estado == null)
                return null;
            var eliminar =_db.Estados.Remove(estado);
            await save();
            return new Estado();
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _db.Estados.ToListAsync();
        }

        public async Task<Estado> Update(Estado estado)
        {
            var actualizar = _db.Estados.Update(estado);
            await save();
            return await _db.Estados.FirstOrDefaultAsync(x => x.IdEstado == estado.IdEstado);
        }

        public async Task<int> save()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
