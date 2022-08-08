namespace EducationalMaterials.Data.DAL
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MaterialsContext context) : base(context) { }
    }
}
