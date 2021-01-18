using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetArmor
	{
		private readonly ApplicationDbContext _ctx;

		public GetArmor(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public Armor Get(int id)
		{
			return _ctx.Armors.Find(id);
		} // Get()

	}
}
