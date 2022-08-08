namespace EducationalMaterials.API.DTOs.Author
{
    public record AuthorDisplayDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public int MaterialCount { get; init; }
    }
}
