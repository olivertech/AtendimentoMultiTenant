namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class ResponseFactory<T>
    {
        /// <summary>
        /// Inidicador booleano de sucesso ou não da resposta
        /// </summary>
        [JsonProperty(PropertyName = "issuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }

        /// <summary>
        /// Conteudo de resposta composto por uma classe com as propriedades preenchidas
        /// que deverão ser retornadas ao requisitante
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public T? Result { get; set; }

        /// <summary>
        /// Métodos que criam o objeto de retorno
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Success(string message, T result)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                Result = result,
                IsSuccess = true
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Error(string message)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                IsSuccess = false
            };
        }
    }
}
