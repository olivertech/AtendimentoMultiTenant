namespace AtendimentoMultiTenant.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /**
             * Mapping Requests ( Request -> Model )
             */
            CreateMap<ContainerDbRequest, ContainerDb>();
            CreateMap<ConfigurationRequest, ContainerDb>();
            CreateMap<TenantRequest, Tenant>();
            CreateMap<UserRequest, User>();

            /**
             * Mapping Responses ( Response <- Model )
             */
            CreateMap<ContainerDb, ContainerDbResponse>();
            CreateMap<ContainerDb, ConfigurationResponse>();
            CreateMap<User, UserLoginResponse>();
            //CreateMap<Tenant, TenantResponse>();
            //CreateMap<User, UserResponse>();
        }
    }
}
