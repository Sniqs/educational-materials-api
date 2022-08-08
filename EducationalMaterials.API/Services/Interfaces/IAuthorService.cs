namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDisplayDto>> GetAllAsync();
    }
}
