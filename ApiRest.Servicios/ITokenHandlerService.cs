using ApiRest.Abstracciones;

namespace ApiRest.Servicios
{
    public interface ITokenHandlerService
    {
        string GenerateJwtToken(ITokenParameters pars);
    }
}
