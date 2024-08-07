namespace AtendimentoMultiTenant.Api.ManagementArea.Helpers
{
    public class IdentifierHelper
    {
        /// <summary>
        /// Método que retorna o id do usuário e o id do token, criptografados
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string SetIdentifier(Guid? tokenAccessId)
        {
            return CryptoHelper.Encrypt(tokenAccessId!.ToString()!);
        }

        /// <summary>
        /// Método que retorna o id do usuário e o id do token, descriptografados
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static Dictionary<string, Guid> GetIdentifier(string identifier)
        {
            var result = CryptoHelper.Decrypt(identifier);

            var dic = new Dictionary<string, Guid>
            {
                //{ "USERID", Guid.Parse(userId) },
                { "TOKENID", Guid.Parse(result) }
            };

            return dic;
        }
    }
}
