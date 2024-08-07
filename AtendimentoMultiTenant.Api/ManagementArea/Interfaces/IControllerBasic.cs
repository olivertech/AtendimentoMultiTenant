namespace AtendimentoMultiTenant.Api.ManagementArea.Interfaces
{
    public interface IControllerBasic<TReq>
        where TReq : IRequest
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> Insert([FromBody] TReq request);
        Task<IActionResult> Update(TReq request);
        Task<IActionResult> Delete(Guid id);
    }
}
