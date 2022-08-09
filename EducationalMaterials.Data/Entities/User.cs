namespace EducationalMaterials.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
