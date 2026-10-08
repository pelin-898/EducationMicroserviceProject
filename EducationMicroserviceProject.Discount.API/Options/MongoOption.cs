using System.ComponentModel.DataAnnotations;

namespace EducationMicroserviceProject.Discount.API.Options
{
    public class MongoOption
    {
       [Required] public string DatabaseName { get; set; } = default!;
       [Required] public string ConnectionString { get; set; }
    }
}
