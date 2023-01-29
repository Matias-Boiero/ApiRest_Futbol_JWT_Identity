namespace ApiRest.WebApi.DTOs
{
    public class UserLoginResponseDTO
    {
        public string Token { get; set; }
        //Para saber si esta autenticado o no
        public bool Login { get; set; }
        //Una lista de errores para ser devuelto en caso de que no pueda loguearse
        public List<string> Errores { get; set; }

    }
}
