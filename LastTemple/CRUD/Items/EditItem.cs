using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class EditItem
	{
		private readonly ApplicationDbContext _ctx;

		public EditItem(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Update(Item item)
		{
			Item target = _ctx.Items.Find(item.Id);

			if (target == null) return false;

			target.Name = item.Name;
			target.ItemType = item.ItemType;
			target.Strength = item.Strength;
			target.ActionCost = item.ActionCost;			

			await _ctx.SaveChangesAsync();

			return true;
		} // Update()
	}
}
