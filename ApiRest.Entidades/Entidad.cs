using ApiRest.Abstracciones;

namespace ApiRest.Entidades
{
    public abstract class Entidad : IEntidad
    {
        public int Id { get; set; }
    }
}
