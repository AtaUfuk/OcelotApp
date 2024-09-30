using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OcelotApp.Products.Models;

namespace OcelotApp.Products.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private List<Product> products { get; set; } = [];
		public ProductsController()
		{
			for (int i = 0; i < 10; i++)
			{
				products.Add(new Product { Id = i, Name = $"Product-{i}", CreatedDate = DateTime.Now, IsActive = i % 2 == 0 });
			}
		}

		[HttpGet("get-all")]
		public IActionResult Get()
		{
			return Ok(products);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(products?.FirstOrDefault(x=>x.Id==id));
		}
	}
}
