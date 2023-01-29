namespace ApiRest.Abstracciones
{
    //Atributos necesarios para la creacion del Token
    public interface ITokenParameters
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
    }
}
