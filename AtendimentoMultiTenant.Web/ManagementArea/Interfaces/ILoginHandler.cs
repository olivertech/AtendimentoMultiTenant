using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;

namespace AtendimentoMultiTenant.Web.ManagementArea.Interfaces
{
    public interface ILoginHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
    }
}
