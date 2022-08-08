namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDisplayDto>> GetAllAsync();
        Task<MaterialTypeDisplayDto> GetSingleAsync(int id);
        Task<IEnumerable<MaterialDisplayDto>> GetTypeMaterialsAsync(int id);
    }
}
