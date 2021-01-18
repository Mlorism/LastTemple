
using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LastTemple.CRUD
{
	public class CreateArmor
	{
		private readonly ApplicationDbContext _ctx;

		public CreateArmor(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Create(Armor armor)
		{
			Armor item = new Armor 
			{ 
				Name = armor.Name,
				DamageResistance = armor.DamageResistance,
				MagicResistance = armor.MagicResistance
			};

			_ctx.Armors.Add(item);

			await _ctx.SaveChangesAsync();

			return true;
		} // Create()

	}
}
