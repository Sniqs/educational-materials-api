namespace EducationalMaterials.API.DTOs.Review
{
    public record ReviewCreateDto
    {
        [Required]
        public int MaterialId { get; init; }
        [Required]
        [MaxLength(255)]
        public string ReviewText { get; init; } = null!;
        [Required]
        [Range(1,10)]
        public byte Rating { get; init; }
    }
}
