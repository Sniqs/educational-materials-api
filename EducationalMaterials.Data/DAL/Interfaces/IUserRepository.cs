namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task LoadRoleAsync(User user);
    }
}
