using MongoDB.Driver;
using System.Reflection;
using DiscountEntity = EducationMicroserviceProject.Discount.API.Features.Discounts.DiscountEntity;

namespace EducationMicroserviceProject.Discount.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<DiscountEntity> Discounts { get; set; } = null!;
        public static AppDbContext Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseMongoDB(database.Client,
                            database.DatabaseNamespace.DatabaseName);

            return new AppDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
