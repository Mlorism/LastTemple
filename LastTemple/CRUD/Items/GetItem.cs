using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetItem
	{
		private readonly ApplicationDbContext _ctx;

		public GetItem(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public Item Get(int id)
		{
			return _ctx.Items.Find(id);
		} // Get()
	}
}
