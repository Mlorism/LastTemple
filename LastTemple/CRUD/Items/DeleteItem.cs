using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class DeleteItem
	{
		private readonly ApplicationDbContext _ctx;

		public DeleteItem(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Delete(int id)
		{
			Item item = _ctx.Items.Find(id);

			if (item == null)
			{
				return false;
			}

			_ctx.Items.Remove(item);
			await _ctx.SaveChangesAsync();

			return true;
		} // Delete()
	}
}
