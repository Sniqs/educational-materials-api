namespace EducationalMaterials.API.DTOs.Material
{
    public record MaterialUpdateDto
    {
        public int Id { get; init; }
        public int AuthorId { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Location { get; init; } = null!;
        public int TypeId { get; init; }
    }
}
