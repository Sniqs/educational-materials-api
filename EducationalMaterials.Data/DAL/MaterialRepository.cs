namespace EducationalMaterials.Data.DAL
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(MaterialsContext context) : base(context) { }

        public async Task LoadReviewsAsync(Material material)
            => await MaterialsContext
                .Entry(material)
                .Collection(r => r.Reviews)
                .LoadAsync();
        
    }
}
