namespace EducationalMaterials.Data.Contexts
{
    public class MaterialsContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<MaterialType> MaterialTypes { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public MaterialsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>(b => b.Property(p => p.Name).HasMaxLength(100));

            builder.Entity<Material>(b =>
            {
                b.Property(p => p.Title).HasMaxLength(255);
                b.Property(p => p.Description).HasMaxLength(255);
                b.Property(p => p.Location).HasMaxLength(255);
            });

            builder.Entity<MaterialType>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(100);
                b.Property(p => p.Definition).HasMaxLength(255);
            });

            builder.Entity<Review>(b =>
            {
                b.Property(p => p.ReviewText).HasMaxLength(255);
            });
        }
    }
}
