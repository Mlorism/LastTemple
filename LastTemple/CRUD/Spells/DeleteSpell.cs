using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class DeleteSpell
	{
		private readonly ApplicationDbContext _ctx;

		public DeleteSpell(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Delete(int id)
		{
			Spell item = _ctx.Spells.Find(id);

			if (item == null)
			{
				return false;
			}

			_ctx.Spells.Remove(item);
			await _ctx.SaveChangesAsync();

			return true;
		} // Delete()

	}
}
