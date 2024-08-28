namespace AtendimentoMultiTenant.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MenuResponse, MenuRequest>();
            CreateMap<ContainerDbResponse, ContainerDbRequest>();
        }
    }
}
