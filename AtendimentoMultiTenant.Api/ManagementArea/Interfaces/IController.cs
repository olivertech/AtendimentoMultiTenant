namespace AtendimentoMultiTenant.Api.ManagementArea.Interfaces
{
    public interface IController<TReq, TReqPaged>
        where TReq : IRequest
        where TReqPaged : IRequest
    {
        Task<IActionResult> GetAll([FromBody] TReqPaged request);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> GetListByName(string name);
        Task<IActionResult> GetCount();
        Task<IActionResult> Insert([FromBody] TReq request);
        Task<IActionResult> Update(TReq request);
        Task<IActionResult> Delete(Guid id);
    }
}
