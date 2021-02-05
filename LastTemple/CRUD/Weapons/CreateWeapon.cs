using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class CreateWeapon
	{
		private readonly ApplicationDbContext _ctx;

		public CreateWeapon(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Create(Weapon weapon)
		{
			Weapon item = new Weapon
			{
				Name = weapon.Name,
				BaseDamage = weapon.BaseDamage,
				MagicDamage = weapon.MagicDamage,
				ActionCost = weapon.ActionCost,
				HitChance = weapon.HitChance			
			};

			_ctx.Weapons.Add(item);

			await _ctx.SaveChangesAsync();

			return true;
		} // Create()
	}
}
