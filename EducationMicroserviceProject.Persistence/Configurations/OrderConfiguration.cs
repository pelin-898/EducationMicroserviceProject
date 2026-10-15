using OrderEntity= EducationMicroserviceProject.Order.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationMicroserviceProject.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();

            builder.Property(x => x.BuyerId).IsRequired(); 
            builder.Property(x => x.Created).IsRequired();        
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.AdressId).IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();   
            builder.Property(x => x.DiscountRate).HasColumnType("float");

            builder.HasMany(x => x.OrderItems).WithOne(x=>x.Order).HasForeignKey(x => x.OrderId);          
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AdressId);

        }
    }
    
}
