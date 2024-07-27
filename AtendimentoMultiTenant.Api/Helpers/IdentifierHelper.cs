namespace AtendimentoMultiTenant.Api.Helpers
{
    public class IdentifierHelper
    {
        /// <summary>
        /// Método que retorna o id do usuário e o id do token, criptografados
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string SetIdentifier(Guid? userId, Guid? tokenId)
        {
            return CryptoHelper.Encrypt(userId + "|" + tokenId);
        }

        /// <summary>
        /// Método que retorna o id do usuário e o id do token, descriptografados
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static Dictionary<string, Guid> GetIdentifier(string identifier)
        {
            var result = CryptoHelper.Decrypt(identifier);

            string[] parts = result.Split(new char[] { '|' });

            var dic = new Dictionary<string, Guid>
            {
                { "USERID", Guid.Parse(parts[0].ToString()) },
                { "TOKENID", Guid.Parse(parts[1].ToString()) }
            };

            return dic;
        }
    }
}
