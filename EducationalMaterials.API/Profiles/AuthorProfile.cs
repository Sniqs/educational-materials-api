namespace EducationalMaterials.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDisplayDto>();
        }
    }
}
