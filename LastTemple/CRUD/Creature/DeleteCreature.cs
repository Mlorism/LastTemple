using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class DeleteCreature
	{
		private readonly ApplicationDbContext _ctx;

		public DeleteCreature(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Delete(int id)
		{
			Creature target = _ctx.Creatures.Find(id);

			if (target == null)
			{
				return false;
			}

			_ctx.Creatures.Remove(target);
			await _ctx.SaveChangesAsync();

			return true;
		} // Delete()
	}
}
