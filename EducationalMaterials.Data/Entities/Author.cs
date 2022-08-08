namespace EducationalMaterials.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Material> Materials { get; set; } = new List<Material>();
        public int MaterialCount { get { return Materials.Count; }}

    }
}
