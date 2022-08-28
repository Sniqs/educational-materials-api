namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDisplayDto>> GetAllAsync();
        Task<MaterialDisplayDto> GetSingleAsync(int id);
        Task<MaterialDisplayDto> CreateAsync(MaterialCreateDto dto);
        Task<MaterialDisplayDto> UpdateAsync(MaterialUpdateDto dto);
        Task DeleteAsync(int id);
        Task<MaterialUpdateDto> GetUpdateDtoForPatch(int id);
    }
}
