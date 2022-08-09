namespace EducationalMaterials.API.DTOs.User
{
    public record UserCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Login { get; init; } = null!;
        [Required]
        public string Password { get; init; } = null!;
        [Required]
        public int RoleId { get; init; }
    }
}
