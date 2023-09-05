namespace Commons.Models;

public class Order
{
    public int Id { get; set; }
    public float Value { get; set; }

    IEnumerable<Item> OrderItems { get; set; }
}