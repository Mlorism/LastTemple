using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetSpells
	{
		private readonly ApplicationDbContext _ctx;

		public GetSpells(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public IEnumerable<Spell> Get()
		{
			return _ctx.Spells.ToList();
		} // Get()
	}
}
