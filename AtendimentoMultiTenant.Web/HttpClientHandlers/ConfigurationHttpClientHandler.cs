namespace AtendimentoMultiTenant.Web.HttpClientHandlers
{
    public class ConfigurationHttpClientHandler : IHttpClientHandler<ConfigurationRequest, ConfigurationResponse>
    {
        public Task<ConfigurationResponse> GetAll(ConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> Insert(ConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> Update(ConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ConfigurationResponse> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
