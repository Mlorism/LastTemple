using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple
{
	public class DeleteWeapon
	{
		private readonly ApplicationDbContext _ctx;

		public DeleteWeapon(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Delete(int id)
		{
			Weapon item = _ctx.Weapons.Find(id);

			if (item == null)
			{
				return false;
			}

			List<Creature> creatures = _ctx.Creatures.Where(x => x.Weapon.Id == id).ToList();

			foreach(var weapon in creatures)
			{
				weapon.Weapon = null;
			}

			_ctx.Weapons.Remove(item);
			await _ctx.SaveChangesAsync();

			return true;
		} // Delete()

	}
}
