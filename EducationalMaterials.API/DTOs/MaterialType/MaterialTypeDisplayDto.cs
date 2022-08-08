namespace EducationalMaterials.API.DTOs.MaterialType
{
    public record MaterialTypeDisplayDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Definition { get; init; } = null!;
    }
}
