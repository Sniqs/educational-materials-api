namespace EducationalMaterials.API.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDisplayDto>();
            CreateMap<MaterialCreateDto, Material>();
            CreateMap<MaterialUpdateDto, Material>();
        }
    }
}
