using MongoDB.Bson.Serialization.Attributes;

namespace EducationMicroserviceProject.Discount.API.Repositories
{
    public class BaseEntity
    {
       public Guid Id { get; set; }
    }
}
