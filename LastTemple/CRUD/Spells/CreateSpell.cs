using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class CreateSpell
	{
		private readonly ApplicationDbContext _ctx;

		public CreateSpell(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Create(Spell spell)
		{
			Spell item = new Spell
			{
				Name = spell.Name,
				Type = spell.Type,
				Level = spell.Level,
				ManaCost = spell.ManaCost,
				ActionCost = spell.ActionCost,
				Strength = spell.Strength
			};

			_ctx.Spells.Add(item);

			await _ctx.SaveChangesAsync();

			return true;
		} // Create()
	}
}
