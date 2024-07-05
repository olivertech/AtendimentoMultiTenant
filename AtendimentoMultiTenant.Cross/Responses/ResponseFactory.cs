namespace AtendimentoMultiTenant.Cross.Responses
{
    public class ResponseFactory<T>
    {
        /// <summary>
        /// Inidicador booleano de sucesso ou não da resposta
        /// </summary>
        public bool Sucess { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string? Message { get; private set; }

        /// <summary>
        /// Conteudo de resposta composto por uma classe com as propriedades preenchidas
        /// que deverão ser retornadas ao requisitante
        /// </summary>
        public T? Content { get; private set; }

        /// <summary>
        /// Métodos que criam o objeto de retorno
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Success(bool sucess, string message, T content)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                Content = content,
                Sucess = sucess
            };
        }

        /// <summary>
        /// Métodos que criam o objeto de retorno para erros
        /// </summary>
        /// <returns></returns>
        public static ResponseFactory<T> Error(bool error, string message)
        {
            return new ResponseFactory<T>()
            {
                Message = message,
                Sucess = error
            };
        }
    }
}
