namespace EducationalMaterials.API.DTOs.User
{
    public record UserDisplayDto
    {
        public int Id { get; init; }
        public string Login { get; init; } = null!;
        public int RoleId { get; init; }
    }
}
