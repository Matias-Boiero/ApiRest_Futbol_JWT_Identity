using ApiRest.Abstracciones;

namespace ApiRest.Repositorio
{



    public class Repositorio<T> : IRepositorio<T> where T : IEntidad
    {
        private readonly Abstracciones.IDbContext<T> _dbContext;

        public Repositorio(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            _dbContext.DeleteById(id);
        }

        public IList<T> GetAll()
        {
            return _dbContext.GetAll();

        }

        public T GetById(int id)
        {
            return _dbContext.GetById(id);
        }

        public T Save(T entity)
        {
            return _dbContext.Save(entity);
        }
    }


}