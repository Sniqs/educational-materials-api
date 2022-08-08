namespace EducationalMaterials.Data.DAL
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(MaterialsContext context) : base(context) { }
    }
}
