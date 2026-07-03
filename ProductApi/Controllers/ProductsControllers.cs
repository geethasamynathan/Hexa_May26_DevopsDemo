using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 55000 },
        new Product { Id = 2, Name = "Mouse", Price = 700 },
        new Product { Id = 3, Name = "Keyboard", Price = 1500 }
    ];

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        product.Id = Products.Max(p => p.Id) + 1;
        Products.Add(product);

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }
}