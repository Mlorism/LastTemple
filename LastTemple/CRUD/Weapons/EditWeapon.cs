using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class EditWeapon
	{
		private readonly ApplicationDbContext _ctx;

		public EditWeapon(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Update(Weapon weapon)
		{
			Weapon target = _ctx.Weapons.Find(weapon.Id);

			if (target == null) return false;

			target.Name = weapon.Name;
			target.BaseDamage = weapon.BaseDamage;
			target.MagicDamage = weapon.MagicDamage;
			target.ActionCost = weapon.ActionCost;
			target.HitChance = weapon.HitChance;			

			await _ctx.SaveChangesAsync();

			return true;
		} // Update()
	}
}
