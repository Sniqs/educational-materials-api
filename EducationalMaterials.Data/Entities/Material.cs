namespace EducationalMaterials.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public Author Author { get; set; } = null!;
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public MaterialType Type { get; set; } = null!;
        public int TypeId { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public double AverageRating { get { return Reviews.Any() ? Reviews.Average(x => x.Rating) : 0; } }
        public DateTime Published { get; set; }

    }
}
