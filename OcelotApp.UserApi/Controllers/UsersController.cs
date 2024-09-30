using Microsoft.AspNetCore.Mvc;
using OcelotApp.UserApi.Models;

namespace OcelotApp.UserApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private List<Users> Users { get; set; } = new();
		public UsersController()
		{
			for (int i = 1; i < 11; i++)
			{
				Users user = new() { Email = $"test{i}@test.com", Name = $"Test{i} User", Id = i };
				Users.Add(user);
			}
		}
		[HttpGet("get-all")]
		public IActionResult Get()
		{
			return Ok(Users);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(Users?.FirstOrDefault(x => x.Id == id));
		}
	}
}
