namespace AtendimentoMultiTenant.Shared.Responses
{
    public class ResponseFactory<T>
    {
        /// <summary>
        /// Armazena o status code da requisição
        /// </summary>
        //public int StatusCode { get; set; }

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

        //[JsonProperty(PropertyName = "messages")]
        //public dynamic? Messages { get; set; }

        /// <summary>
        /// Conteudo de resposta composto por uma classe com as propriedades preenchidas
        /// que deverão ser retornadas ao requisitante
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public T? Content { get; set; }

        /// <summary>
        /// Métodos que criam o objeto de retorno
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Success(bool isSuccess, string message, T content)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                Content = content,
                IsSuccess = isSuccess
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Error(bool isSuccess, string message)
        {
            return new ResponseFactory<T>()
            {
                //StatusCode = statusCode,
                Message = message,
                IsSuccess = isSuccess
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        //public static ResponseFactory<T> Error(bool isSuccess, dynamic messages)
        //{
        //    return new ResponseFactory<T>()
        //    {
        //        //StatusCode = statusCode,
        //        Messages = messages!,
        //        IsSuccess = isSuccess
        //    };
        //}
    }
}
