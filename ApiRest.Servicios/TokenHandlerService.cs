using ApiRest.Abstracciones;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRest.Servicios
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JwtConfig _jwtConfig;

        //el objeto IOptionsMonitor trae las opciones de config del JwtConfig
        public TokenHandlerService(IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        //En el siguiente metodo para la creacion de Tokens inyecto la dependencia del ITokenParameter
        //que hice en Abstracciones
        public string GenerateJwtToken(ITokenParameters pars)
        {
            //instancio el objeto JwtSecurityTokenHandler() que me permite crear un nuevo token de seguridad
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            // Creo la clave con la que firmaré el Token 
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            // Configuro la descripcion del token mediante las claims que son los atributos que tendrá el token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
               {
                    new Claim("Id", pars.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, pars.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, pars.UserName),

                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

            };
            //Paso final, la creación del token
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
