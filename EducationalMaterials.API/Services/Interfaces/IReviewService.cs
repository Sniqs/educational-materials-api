namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDisplayDto>> GetAllAsync();
        Task<ReviewDisplayDto> GetSingleAsync(int id);
    }
}
