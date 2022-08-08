namespace EducationalMaterials.API.Profiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialType, MaterialTypeDisplayDto>();
        }
    }
}
