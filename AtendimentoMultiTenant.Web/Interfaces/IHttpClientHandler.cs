namespace AtendimentoMultiTenant.Web.Interfaces
{
    public interface IHttpClientHandler<TReq, TResp> 
        where TReq : IRequest
        where TResp : IResponse
    {
        Task<TResp> GetAll(TReq request);
        Task<TResp> GetById(Guid id);
        Task<TResp> GetListByName(string name);
        Task<TResp> GetCount();
        Task<TResp> Insert(TReq request);
        Task<TResp> Update(TReq request);
        Task<TResp> Delete(Guid id);
    }
}
