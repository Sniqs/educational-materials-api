namespace EducationalMaterials.API.DTOs.Material
{
    public record MaterialUpdateDto
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public int AuthorId { get; init; }
        [Required]
        [MaxLength(255)]
        public string Title { get; init; } = null!;
        [Required]
        [MaxLength(255)]
        public string Description { get; init; } = null!;
        [Required]
        [MaxLength(255)]
        public string Location { get; init; } = null!;
        [Required]
        public int TypeId { get; init; }
    }
}
