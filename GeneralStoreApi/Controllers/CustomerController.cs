using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private GeneralStoreDbContext _db;
    public CustomerController(GeneralStoreDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest newCustomer)
    {
        Customer customer = new()
        {
            Name = newCustomer.Name,
            Email = newCustomer.Email
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        List<Customer> customers = await _db.Customers.ToListAsync();
        return Ok(customers);
    }
}