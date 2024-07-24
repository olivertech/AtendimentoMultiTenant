using AtendimentoMultiTenant.Shared.Interfaces;

namespace AtendimentoMultiTenant.Api.Interfaces
{
    public interface IController<TReq, TReqPaged> 
        where TReq : IRequest
        where TReqPaged : IRequest
    {
        Task<IActionResult> GetAll([FromBody] TReqPaged request);
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> GetListByName(string name);
        Task<IActionResult> GetCount();
        Task<IActionResult> Insert([FromBody] TReq request);
        Task<IActionResult> Update(TReq request);
        Task<IActionResult> Delete(Guid id);
    }
}
