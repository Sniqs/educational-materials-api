namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDisplayDto>> GetAllAsync();
    }
}
