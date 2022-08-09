namespace EducationalMaterials.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(m => m.PasswordHash, o => o.MapFrom(u => u.Password));
            CreateMap<User, UserDisplayDto>();
        }
    }
}
