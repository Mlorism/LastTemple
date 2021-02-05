using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetCreatures
	{
		private readonly ApplicationDbContext _ctx;

		public GetCreatures(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public IEnumerable<Creature> Get()
		{
			return _ctx.Creatures.ToList();
		} // Get()
	}
}
