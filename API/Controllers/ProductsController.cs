using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _repo;
		public ProductsController(IProductRepository repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var products = await _repo.GetProductsAsync();

			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			return await _repo.GetProductByIdAsync(id);
		}
	}	
}