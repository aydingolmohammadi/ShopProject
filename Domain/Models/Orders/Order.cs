using Domain.Models.OrderItems;

namespace Domain.Models.Orders;

public abstract class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    public ICollection<OrderItem>? OrderItem { get; set; }
}