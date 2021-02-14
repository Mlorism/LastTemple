using LastTemple.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetWeapons
	{
		private readonly ApplicationDbContext _ctx;

		public GetWeapons(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public IEnumerable<Weapon> Get()
		{
			return _ctx.Weapons.ToList();
		} // Get()

	}
}
