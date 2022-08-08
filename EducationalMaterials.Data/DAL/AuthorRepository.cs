namespace EducationalMaterials.Data.DAL
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MaterialsContext context) : base(context) { }

        public async Task<IEnumerable<Material>> GetMaterialsWithReviewsAsync(int authorId)
        {
            var materials = await MaterialsContext.Materials
                .Where(m => m.AuthorId == authorId)
                .Include(r => r.Reviews)
                .ToListAsync();

            if (!materials.Any())
                throw new ResourceNotFoundException($"Requested resource doesn't exist.");

            return materials;
        }
    }
}
