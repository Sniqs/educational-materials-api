namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IMaterialTypeRepository : IRepository<MaterialType>
    {
        Task<IEnumerable<Material>> GetMaterialsOfTypeAsync(int id);
    }
}
