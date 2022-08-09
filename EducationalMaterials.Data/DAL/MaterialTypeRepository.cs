namespace EducationalMaterials.Data.DAL
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(MaterialsContext context) : base(context) { }

        public async Task<IEnumerable<Material>> GetMaterialsOfTypeAsync(int id)
        { 
            var materials = await MaterialsContext.Materials
                .Where(m => m.TypeId == id)
                .Include(r => r.Reviews)
                .ToListAsync();

            if (!materials.Any())
                throw new ResourceNotFoundException("There are no materials of this type.");

            return materials;
        }
    }
}
