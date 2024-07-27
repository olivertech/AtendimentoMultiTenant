namespace AtendimentoMultiTenant.Web.ManagementArea.Interfaces
{
    public interface IHandler<TReq, TResp>
        where TReq : IRequest
        where TResp : IResponse
    {
        Task<ResponsePagedFactory<IEnumerable<TResp>>> GetAll(TReq request);
        Task<ResponseFactory<TResp>> GetById(Guid id);
        Task<ResponseFactory<IEnumerable<TResp>>> GetListByName(string name);
        Task<int> GetCount();
        Task<ResponseFactory<TResp>> Insert(TReq request);
        Task<ResponseFactory<TResp>> Update(TReq request);
        Task<ResponseFactory<TResp>> Delete(Guid id);
    }
}
