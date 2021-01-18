﻿using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class DeleteArmor
	{
		private readonly ApplicationDbContext _ctx;

		public DeleteArmor(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Delete(int id)
		{
			Armor item = _ctx.Armors.Find(id);

			if (item == null)
			{
				return false;
			}

			_ctx.Armors.Remove(item);
			await _ctx.SaveChangesAsync();

			return true;
		} // Delete()


	}
}
