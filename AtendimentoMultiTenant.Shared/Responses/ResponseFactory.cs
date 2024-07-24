namespace AtendimentoMultiTenant.Shared.Responses
{
    public sealed class ResponseFactory<T>
    {
        /// <summary>
        /// Armazena o status code da requisição
        /// </summary>
        //public int StatusCode { get; set; }

        /// <summary>
        /// Inidicador booleano de sucesso ou não da resposta
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public bool Result { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string? Message { get; private set; }

        /// <summary>
        /// Conteudo de resposta composto por uma classe com as propriedades preenchidas
        /// que deverão ser retornadas ao requisitante
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public T? Content { get; private set; }

        /// <summary>
        /// Métodos que criam o objeto de retorno
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Success(bool result, string message, T content)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                Content = content,
                Result = result
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Error(bool result, string message)
        {
            return new ResponseFactory<T>()
            {
                //StatusCode = statusCode,
                Message = message,
                Result = result
            };
        }
    }
}
