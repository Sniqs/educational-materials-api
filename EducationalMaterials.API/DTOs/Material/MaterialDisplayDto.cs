namespace EducationalMaterials.API.DTOs.Material
{
    public record MaterialDisplayDto
    {
        public int Id { get; init; }
        public int AuthorId { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Location { get; init; } = null!;
        public int TypeId { get; init; }
        public double AverageRating { get; init; }
        public DateTime Published { get; init; }
    }
}
