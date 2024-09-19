namespace AtendimentoMultiTenant.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContainerDbResponse, ContainerDbRequest>();
            CreateMap<MenuResponse, MenuRequest>();
            CreateMap<RoleResponse, RoleRequest>();
            CreateMap<TenantResponse, TenantRequest>();
        }
    }
}
