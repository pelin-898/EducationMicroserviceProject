using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationMicroserviceProject.Order.Domain.Entities
{
    public class Order :BaseEntity<Guid>
    {
        public string Code { get; set; } = null!;
        public DateTime Created { get; set; }
        public Guid BuyerId { get; set; }
        public OrderStatus Status { get; set; }
        public int AdressId { get; set; }
        public decimal TotalPrice { get; set; }
        public float? DiscountRate { get; set; }
        public Guid? PaymentId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();

        public Address Address {get;set;} = null!;
        public static string GenerateCode()
        {
            var random = new Random();
            var orderCode = new StringBuilder(10);
            for(int i=0;i<10;i++)
            { 
                orderCode.Append(random.Next(0, 10));
            }
            return orderCode.ToString();
        }
        public static Order CreateUnPaidOrder(Guid buyerId, float? discountRate, int adressId)
        {
            return new Order
            {
                Id= NewId.NextGuid(),
                Code = GenerateCode(),
                BuyerId = buyerId,
                Created = DateTime.Now,
                Status = OrderStatus.WaitingForPayment,
                AdressId = adressId,
                DiscountRate = discountRate,
                TotalPrice = 0
            };
        }
        public void AddOrderItem(Guid productId, string productName, decimal unitPrice)
        {
            var orderItem = new OrderItem();
            orderItem.SetItem(productId, productName, unitPrice);
            OrderItems.Add(orderItem);
            CalculateTotalPrice();
        }
        public void ApplyDiscount(float discountPersentage)
        {
            if (discountPersentage < 0 || discountPersentage > 100)
            {
                throw new ArgumentNullException("Discount percentage must be between 0 and 100.");
            }
            DiscountRate = discountPersentage;
            CalculateTotalPrice();
        }
        public void SetPaidStatus(Guid paymentId)
        {
            Status = OrderStatus.Paid;
            this.PaymentId = paymentId;
        }
        private void CalculateTotalPrice()
        {
            TotalPrice = OrderItems.Sum(item => item.UnitPrice);
            if (DiscountRate.HasValue)
            {
                TotalPrice -= TotalPrice * (decimal)(DiscountRate.Value / 100);
            }
        }
    }
}
