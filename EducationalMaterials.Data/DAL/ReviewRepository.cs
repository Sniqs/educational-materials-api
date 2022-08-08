namespace EducationalMaterials.Data.DAL
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MaterialsContext context) : base(context) { }
    }
}
