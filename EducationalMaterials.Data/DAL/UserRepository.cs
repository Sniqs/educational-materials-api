namespace EducationalMaterials.Data.DAL
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MaterialsContext context) : base(context) { }

        public async Task LoadRoleAsync(User user)
            => await MaterialsContext
                .Entry(user)
                .Reference(r => r.Role)
                .LoadAsync();
    }
}
