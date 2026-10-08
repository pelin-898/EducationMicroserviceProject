using EducationMicroserviceProject.Catalog.API.Features.Categories;
using EducationMicroserviceProject.Catalog.API.Features.Courses;
using MongoDB.Driver;

namespace EducationMicroserviceProject.Catalog.API.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExt(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!dbContext.Categories.Any())
            {
                var categories = new List<CategoryEntity>
                {
                    new CategoryEntity { Id = NewId.NextSequentialGuid(), Name = "Development" },
                    new CategoryEntity { Id = NewId.NextSequentialGuid(), Name = "Business" },
                    new CategoryEntity { Id = NewId.NextSequentialGuid(), Name = "It & Software" },
                    new CategoryEntity { Id = NewId.NextSequentialGuid(), Name = "Personel Development" }
                };

                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Courses.Any())
            {
                var category = await dbContext.Categories.FirstAsync();
                var randomUserId = NewId.NextGuid();

                List<CourseEntity> courses =
                    [
                        new CourseEntity
                        {
                            Id = NewId.NextSequentialGuid(),
                            Name = "C#",
                            Description = "C# course",
                            Price = 100,
                            UserId = randomUserId,
                            Created= DateTime.UtcNow,
                            Feature = new Feature
                            {
                                Duration = 10,
                                Rating = 4,
                                EducatorFullName = "Ahmet Yıldız"
                            },
                            CategoryId = category.Id
                        },
                        new CourseEntity
                        {
                            Id = NewId.NextSequentialGuid(),
                            Name = "Java",
                            Description = "Java Course",
                            Price = 200,
                            UserId = randomUserId,
                            Created= DateTime.UtcNow,
                            Feature = new Feature
                                {
                                    Duration = 10,
                                    Rating = 4,
                                    EducatorFullName = "Ahmet Yıldız"
                                },
                            CategoryId = category.Id
                        },
                            new CourseEntity
                        {
                            Id = NewId.NextSequentialGuid(),
                            Name = "Phyton",
                            Description = "Phyton Course",
                            Price = 300,
                            UserId = randomUserId,
                            Created= DateTime.UtcNow,
                            Feature = new Feature
                                {
                                    Duration = 10,
                                    Rating = 4,
                                    EducatorFullName = "Ahmet Yıldız"
                                },
                            CategoryId = category.Id
                        }
                    ];
                dbContext.Courses.AddRange(courses);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
