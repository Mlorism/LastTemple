using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Controllers
{
	[Route("[controller]")]
	public class ManageArmours : Controller
	{
		private readonly ApplicationDbContext _ctx;

		public ManageArmours(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		#region Armour

		[HttpGet("armours/{id}")]
		public IActionResult GetArmour(int id) => Ok(new GetArmor(_ctx).Get(id));

		[HttpDelete("armours/{id}")]
		public async Task<IActionResult> DeleteArmour(int id) => Ok(await new DeleteArmor(_ctx).Delete(id));



		#endregion
	}
}
