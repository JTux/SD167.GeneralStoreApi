using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private GeneralStoreDbContext _db;
    public ProductController(GeneralStoreDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest newProduct)
    {
        Product product = new()
        {
            Name = newProduct.Name,
            Price = newProduct.Price,
            QuantityInStock = newProduct.Quantity
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        List<Product> products = await _db.Products.ToListAsync();
        return Ok(products);
    }
}