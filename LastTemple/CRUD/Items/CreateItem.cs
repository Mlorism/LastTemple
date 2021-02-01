using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class CreateItem
	{
		private readonly ApplicationDbContext _ctx;

		public CreateItem(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Create(Item item)
		{
			Item target = new Item
			{
				Name = item.Name,
				ItemType = item.ItemType,
				Strength = item.Strength,
				ActionCost = item.ActionCost
		};

			_ctx.Items.Add(target);

			await _ctx.SaveChangesAsync();

			return true;
		} // Create()
	}
}
