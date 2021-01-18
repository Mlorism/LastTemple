using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class EditArmor
	{
		private readonly ApplicationDbContext _ctx;

		public EditArmor(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Update(Armor armor)
		{
			Armor target = _ctx.Armors.Find(armor.Id);

			if (target == null) return false;

			target.Name = armor.Name;
			target.DamageResistance = armor.DamageResistance;
			target.MagicResistance = armor.MagicResistance;

			await _ctx.SaveChangesAsync();

			return true;
		} // Update()

	}
}
