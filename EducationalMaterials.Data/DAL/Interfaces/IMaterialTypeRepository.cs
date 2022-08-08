namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IMaterialTypeRepository : IRepository<MaterialType>
    {
        Task<IEnumerable<Material>> GetTypeMaterialsAsync(int id);
    }
}
