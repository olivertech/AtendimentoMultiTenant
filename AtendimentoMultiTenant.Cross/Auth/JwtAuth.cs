namespace AtendimentoMultiTenant.Cross.Auth
{
    public static class JwtAuth
    {
        public static string GenerateToken(User user, string identifier, IConfiguration configuration, ref DateTime expirationDate)
        {
            expirationDate = DateTime.UtcNow.AddMinutes(Configurations.MINUTES);

            //Recupera as configurações JWT
            var key = Encoding.UTF8.GetBytes(JwtSettings.SecretKey);
            var issuer = JwtSettings.JwtIssuer;
            var audience = JwtSettings.JwtAudience;

            //Monta o descritivo JWT que conterá todos os dados associados ao acesso, que serão incluídos no token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name!.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType!.Name!.ToString()),
                    new Claim(ClaimTypes.Hash, identifier!), //Identifier = UserId + "|" + TokenId
                }),
                Expires = expirationDate,
                Issuer = issuer,
                Audience = audience,

                //Define o algoritmo usado na criptografia da token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            //Cria e assina digitalmente o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            //TODO: ENCRIPTAR O TOKEN POSTERIORMENTE
            return tokenHandler.WriteToken(token);
        }
    }
}
