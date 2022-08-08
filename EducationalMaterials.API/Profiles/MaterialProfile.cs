namespace EducationalMaterials.API.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDisplayDto>();
        }
    }
}
