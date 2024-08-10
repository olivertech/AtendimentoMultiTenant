namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public sealed class ResponsePagedFactory<T> : ResponsePagedBase
    {
        /// <summary>
        /// Inidicador booleano de sucesso ou não da resposta
        /// </summary>
        [JsonProperty(PropertyName = "issuccess")]
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string? Message { get; private set; }

        /// <summary>
        /// Conteudo de resposta composto por uma classe com as propriedades preenchidas
        /// que deverão ser retornadas ao requisitante
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public T? Result { get; private set; }

        /// <summary>
        /// Métodos que criam o objeto de retorno
        /// </summary>
        /// <returns></returns>
        public static ResponsePagedFactory<T> Success(string message, T result, int pageNumber, int totalCount)
        {
            return new ResponsePagedFactory<T>()
            {
                PageNumber = pageNumber,
                TotalCount = totalCount,
                Message = message,
                Result = result,
                IsSuccess = true
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponsePagedFactory<T> Error(string message)
        {
            return new ResponsePagedFactory<T>()
            {
                Message = message,
                IsSuccess = false
            };
        }
    }
}
