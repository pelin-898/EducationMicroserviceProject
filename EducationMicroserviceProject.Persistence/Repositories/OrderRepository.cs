using EducationMicroserviceProject.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationMicroserviceProject.Persistence.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Order.Domain.Entities.Order>(context), IOrderRepository
    {
       
    }
}
