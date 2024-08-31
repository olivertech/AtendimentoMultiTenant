namespace AtendimentoMultiTenant.Api.ManagementArea.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /**
             * Mapping Requests ( Request -> Model )
             */
            CreateMap<ContainerDbRequest, ContainerDb>();
            CreateMap<TenantRequest, Tenant>();
            CreateMap<UserRequest, User>();
            CreateMap<MenuRequest, Menu>();
            CreateMap<FeatureRequest, Feature>();
            CreateMap<RoleRequest, Role>();

            /**
             * Mapping Responses ( Response <- Model )
             */
            CreateMap<ContainerDb, ContainerDbResponse>();
            CreateMap<User, LoginResponse>();
            CreateMap<Menu, MenuResponse>();
            CreateMap<LogAccess, LogAccessResponse>();
            CreateMap<Feature, FeatureResponse>();
            CreateMap<Role, RoleResponse>();
        }
    }
}
