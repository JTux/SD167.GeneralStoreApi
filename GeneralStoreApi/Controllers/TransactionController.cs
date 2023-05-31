using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private GeneralStoreDbContext _db;
    public TransactionController(GeneralStoreDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromForm] TransactionRequest newTransaction)
    {
        Transaction transaction = new()
        {
            CustomerId = newTransaction.CustomerId,
            ProductId = newTransaction.ProductId,
            Quantity = newTransaction.Quantity,
            DateOfTransaction = DateTime.Now
        };

        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();

        return Ok(transaction);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        List<Transaction> transactions = await _db.Transactions.ToListAsync();
        return Ok(transactions);
    }
}