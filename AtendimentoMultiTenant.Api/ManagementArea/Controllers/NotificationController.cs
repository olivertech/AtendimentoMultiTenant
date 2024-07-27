namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/Notification")]
    [SwaggerTag("Notification")]
    [ApiController]
    public class NotificationController : Base.ControllerBase
    {
        private readonly IHttpClientFactory? _httpClientFactory;
        private readonly ILogger<NotificationController>? _logger;
        private string AppId { get; } = "a7584c97-7a8c-422e-9e08-fc044d7d48da";
        private string ApiKey { get; } = "ZDczYmMxZTQtZTNmZS00NDIyLTgyYzQtMWUyYzgxZGI4MTNm";
        private string ApiUrl { get; } = "https://onesignal.com/api/v1/notifications";

        public NotificationController(IHttpClientFactory httpClientFactory,
                                      IUnitOfWork unitOfWork,
                                      IMapper? mapper,
                                      IConfiguration configuration,
                                      ILogger<NotificationController>? logger)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Notification";
            _httpClientFactory = httpClientFactory;
            _logger = logger;

            //this.defaultClient = factory.CreateClient(); // BaseAddress: null
            //this.namedClient = factory.CreateClient("githubClient");
        }

        [HttpPost]
        [Route(nameof(SendPush))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<ActionResult> SendPush()
        {
            try
            {
                var httpRequestMessage1 = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
                {
                    Headers = {
                        { HeaderNames.Accept, "application/json" },
                        { HeaderNames.UserAgent, "HttpRequestsSample" },
                        { HeaderNames.Authorization, $"Basic {_configuration!["OneSignal:AppId"]}"}}
                };

                //var result = await ApiUrl
                //    .WithHeader("Accept", "application/json")
                //    .WithHeader("authorization", $"Basic {_configuration!["OneSignal:AppId"]}")
                //    .WithHeader("Connection", "keep-alive")
                //    .PostJsonAsync(new
                //    {
                //        app_id = _configuration!["OneSignal:AppId"],
                //        contents = new { en = "Mensagem de teste" },
                //        included_segments = new List<string> { "All" }
                //    })
                //    .ReceiveJson<Object>();

                var httpClient = _httpClientFactory!.CreateClient();

                var httpResponseMessage1 = await httpClient.SendAsync(httpRequestMessage1);

                if (httpResponseMessage1.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage1.Content.ReadAsStreamAsync();
                }

                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                //client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, _nomeEntidade);
                //client.DefaultRequestHeaders.Add("authorization", $"Basic {_configuration!["OneSignal:AppId"]}");

                //var notification = new
                //{
                //    app_id = _configuration!["OneSignal:AppId"],
                //    contents = new { en = "Mensagem de teste" },
                //    included_segments = new List<string> { "All" }
                //};

                //var response = await client.PostAsJsonAsync("notifications", notification);

                //if (response.IsSuccessStatusCode)
                //{
                return Ok(new { Message = "Notificação enviada com sucesso!" });
                //}
                //else
                //{
                //    _logger!.LogError("SendPushNotification");
                //    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<string>.Error(false, "Erro no envio da notificação!"));
                //}
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "SendPushNotification");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<string>.Error(false, "Erro no envio da notificação!"));
            }
        }
    }
}
