namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Material>> GetMaterialsWithReviewsAsync(int authorId);
    }
}
