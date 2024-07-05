namespace AtendimentoMultiTenant.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /**
             * Mapping Requests ( Request -> Model )
             */
            CreateMap<ContainerRequest, Core.Entities.ConfigurationEntities.Container>();
            CreateMap<ConfigurationRequest, Core.Entities.ConfigurationEntities.Container>();
            CreateMap<TenantRequest, Tenant>();
            CreateMap<UserRequest, User>();

            /**
             * Mapping Responses ( Response <- Model )
             */
            CreateMap<Core.Entities.ConfigurationEntities.Container, ContainerResponse>();
            //CreateMap<Tenant, TenantResponse>();
            //CreateMap<User, UserResponse>();
        }
    }
}
