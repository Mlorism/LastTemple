using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class EditSpell
	{
		private readonly ApplicationDbContext _ctx;

		public EditSpell(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Update(Spell spell)
		{
			Spell target = _ctx.Spells.Find(spell.Id);

			if (target == null) return false;					

			target.Name = spell.Name;
			target.Type = spell.Type;
			target.Level = spell.Level;
			target.ManaCost = spell.ManaCost;
			target.ActionCost = spell.ActionCost;
			target.Strenght = spell.Strenght;

			await _ctx.SaveChangesAsync();

			return true;
		} // Update()
	}
}
