namespace AtendimentoMultiTenant.Api.Interfaces
{
    public interface IController
    {
        Task<IActionResult> GetAll([FromBody] ContainerDbPagedRequest request);
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> GetListByName(string name);
        Task<IActionResult> GetCount();
        Task<IActionResult> Insert([FromBody] ConfigurationRequest request);
        Task<IActionResult> Update(ContainerDbRequest request);
        Task<IActionResult> Delete(Guid id);
    }
}
