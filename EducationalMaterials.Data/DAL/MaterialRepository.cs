namespace EducationalMaterials.Data.DAL
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(MaterialsContext context) : base(context) { }
    }
}
