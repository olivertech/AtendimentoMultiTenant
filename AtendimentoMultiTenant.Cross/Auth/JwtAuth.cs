namespace AtendimentoMultiTenant.Cross.Auth
{
    public static class JwtAuth
    {
        public static string GenerateToken(User user, IConfiguration configuration, ref DateTime expirationDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            expirationDate = new DateTime(2030, 01, 19, 0, 0, 0, DateTimeKind.Utc); //DateTime.UtcNow.AddSeconds(1200);
            //DateTime notBeforeDate = new DateTime(2029, 01, 01, 0, 0, 0, DateTimeKind.Utc);

            //DateTime centuryBegin = new DateTime(1970, 1, 1);
            //expirationDate = new TimeSpan(DateTime.Now.AddDays(90).Ticks - centuryBegin.Ticks).TotalSeconds;

            var key = Encoding.UTF8.GetBytes(JwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name!.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType!.Name!.ToString()),
                    new Claim(ClaimTypes.Email, user.Email!.ToString()),
                    new Claim(ClaimTypes.Authentication, user.Password!.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),

                //Define o algoritmo usado na criptografia da token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //Cria e assina digitalmente o token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        //public static int? ValidateJwtToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes(JwtSettings.SecretKey);
        //    try
        //    {
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

        //        // return account id from JWT token if validation successful
        //        return accountId;
        //    }
        //    catch
        //    {
        //        // return null if validation fails
        //        return null;
        //    }
        //}
    }
}
