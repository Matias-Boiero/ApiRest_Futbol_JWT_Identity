namespace ApiRest.Abstracciones
{
    public interface ICrud<T>
    {
        T GetById(int id);
        //el Save Inserta y actualiza
        T Save(T entity);
        //T Update(T entity);
        void DeleteById(int id);
        IList<T> GetAll();
    }
}
