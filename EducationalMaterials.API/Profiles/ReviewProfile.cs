namespace EducationalMaterials.API.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDisplayDto>();
            CreateMap<ReviewCreateDto, Review>();
        }
    }
}
