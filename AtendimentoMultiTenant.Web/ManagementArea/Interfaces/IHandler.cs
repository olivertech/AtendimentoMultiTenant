using System.Linq.Expressions;

namespace AtendimentoMultiTenant.Web.ManagementArea.Interfaces
{
    public interface IHandler<TReq, TReqPaged, TResp>
        where TReq : IRequest
        where TReqPaged : IRequest
        where TResp : IResponse
    {
        Task<ResponseFactory<IEnumerable<TResp>>> GetAll();
        Task<ResponsePagedFactory<IEnumerable<TResp>>> GetAll(TReqPaged request);
        Task<IEnumerable<TResp>?> GetList(Expression<Func<TReq, bool>> predicate);
        Task<ResponseFactory<TResp>> GetById(Guid id);
        Task<ResponseFactory<IEnumerable<TResp>>> GetListByName(string name);
        Task<int> GetCount();
        Task<ResponseFactory<TResp>> Insert(TReq request);
        Task<ResponseFactory<TResp>> Update(TReq request);
        Task<ResponseFactory<TResp>> Delete(Guid id);
    }
}
