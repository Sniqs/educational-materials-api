namespace EducationalMaterials.API.DTOs.Material
{
    public class MaterialDisplayDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int TypeId { get; set; }
        public double AverageRating { get; set; }
        public DateTime Published { get; set; }
    }
}
