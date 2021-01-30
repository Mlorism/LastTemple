using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetSpell
	{
		private readonly ApplicationDbContext _ctx;

		public GetSpell(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public Spell Get(int id)
		{
			return _ctx.Spells.Find(id);
		} // Get()
	}
}
