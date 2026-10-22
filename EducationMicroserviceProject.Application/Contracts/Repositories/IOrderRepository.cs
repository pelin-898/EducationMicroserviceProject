using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationMicroserviceProject.Application.Contracts.Repositories
{
    public interface IOrderRepository :IGenericRepository<Guid,Order.Domain.Entities.Order>    
    {
    }
}
