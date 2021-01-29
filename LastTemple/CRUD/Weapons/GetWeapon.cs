using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetWeapon
	{
		private readonly ApplicationDbContext _ctx;

		public GetWeapon(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public Weapon Get(int id)
		{
			return _ctx.Weapons.Find(id);
		} // Get()
	}
}
