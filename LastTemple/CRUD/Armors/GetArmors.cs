using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetArmors
	{
		private readonly ApplicationDbContext _ctx;

		public GetArmors(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public IEnumerable<Armor> Get()
		{
			return _ctx.Armors.ToList();
		} // Get()
	}
}
