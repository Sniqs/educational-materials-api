namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task LoadReviewsAsync(Material material);
    }
}
