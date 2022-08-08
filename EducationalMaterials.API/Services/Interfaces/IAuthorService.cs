namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDisplayDto>> GetAllAsync();
        Task<AuthorDisplayDto> GetSingleAsync(int id);
        Task<IEnumerable<MaterialDisplayDto>> GetBestMaterialsAsync(int authorId);
    }
}
