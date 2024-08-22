namespace OOPSample.Sales.Domain.Model.Aggregates;

public class SalesOrderItem
{
    public SalesOrderItem(Guid salesOrderId, int productId, int quantity, double unitPrice)
    {
        if (salesOrderId == Guid.Empty)
            throw new ArgumentException("Sales Order ID is required");
        
        if (productId <= 0)
            throw new ArgumentException("Product ID is required");
        
        if (quantity <= 0)
            throw new ArgumentException("Quantity is required");
        
        if (unitPrice <= 0)
            throw new ArgumentException("Unit Price is required");
        
        SalesOrderId = salesOrderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    public double CalculateItemPrice() => Quantity * UnitPrice;
    
    public Guid Id { get; private set; } = GenerateOrderItemId(); //UUID = GUID
    public Guid SalesOrderId { get; }
    public int ProductId { get;}
    public int Quantity { get; }
    public double UnitPrice { get; }
    
    private static Guid GenerateOrderItemId()
    {
        return Guid.NewGuid();
    }
}