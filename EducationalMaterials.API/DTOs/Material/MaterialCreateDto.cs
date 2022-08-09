namespace EducationalMaterials.API.DTOs.Material
{
    public record MaterialCreateDto
    {
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
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Published { get; init; }
    }
}
