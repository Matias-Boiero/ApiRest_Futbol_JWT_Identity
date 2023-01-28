using ApiRest.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.AccesoDatos
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntidad
    {
        private readonly ApiDbContext _dbContext;
        DbSet<T> _contex;

        public DbContext(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _contex = dbContext.Set<T>(); //con esta configuracion puedo setear la entidad cual sea que fuera
        }

        //Ahora con la herencia del IEntidad donde guardo El Id puedo eliminar el objeto especificado
        public void DeleteById(int id)
        {
            var entidad = _contex.FirstOrDefault(x => x.Id == id);
            if (entidad != null)
            {
                _contex.Remove(entidad);
            }
            _dbContext.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _contex.ToList();
        }

        public T GetById(int id)
        {
            return _contex.FirstOrDefault(x => x.Id == id);
        }

        public T Save(T entity)
        {
            _contex.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}