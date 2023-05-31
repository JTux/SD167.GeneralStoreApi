namespace GeneralStoreApi.Models;

public class TransactionRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}