namespace EducationalMaterials.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public Material Material { get; set; } = null!;
        public int MaterialId { get; set; }
        public string ReviewText { get; set; } = null!;
        public byte Rating { get; set; }
    }
}
