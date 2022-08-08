namespace EducationalMaterials.API.DTOs.Review
{
    public record ReviewUpdateDto
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public int MaterialId { get; init; }
        [Required]
        [MaxLength(255)]
        public string ReviewText { get; init; } = null!;
        [Required]
        [Range(1, 10)]
        public byte Rating { get; init; }
    }
}
