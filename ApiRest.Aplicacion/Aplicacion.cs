using ApiRest.Abstracciones;
using ApiRest.Repositorio;

namespace ApiRest.Aplicacion
{


    public class Aplicacion<T> : IAplicacion<T> where T : IEntidad
    {
        private readonly IRepositorio<T> _repository;


        public Aplicacion(IRepositorio<T> repository)
        {
            _repository = repository;

        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }


    }
}
