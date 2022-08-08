namespace EducationalMaterials.API.DTOs.Review
{
    public record ReviewDisplayDto
    {
        public int Id { get; init; }
        public int MaterialId { get; init; }
        public string ReviewText { get; init; } = null!;
        public byte Rating { get; init; }
    }
}
