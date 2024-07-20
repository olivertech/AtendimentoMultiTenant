namespace AtendimentoMultiTenant.Cross.Responses
{
    public sealed class ResponsePagedFactory<T> : ResponsePagedBase
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
        public static ResponsePagedFactory<T> Success(bool result, string message, T content, int currentPage, int totalCount)
        {
            return new ResponsePagedFactory<T>()
            {
                CurrentPage = currentPage,
                TotalCount = totalCount,
                Message = message,
                Content = content,
                Result = result
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponsePagedFactory<T> Error(bool result, string message)
        {
            return new ResponsePagedFactory<T>()
            {
                //StatusCode = statusCode,
                Message = message,
                Result = result
            };
        }
    }
}
