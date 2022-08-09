namespace EducationalMaterials.Data.DAL
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MaterialsContext context) : base(context) { }
    }
}
