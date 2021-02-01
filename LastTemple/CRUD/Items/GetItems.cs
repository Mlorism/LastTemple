using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetItems
	{
		private readonly ApplicationDbContext _ctx;

		public GetItems(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public IEnumerable<Item> Get()
		{
			return _ctx.Items.ToList();
		} // Get()
	}
}
