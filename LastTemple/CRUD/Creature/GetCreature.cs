﻿using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class GetCreature
	{
		private readonly ApplicationDbContext _ctx;

		public GetCreature(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public Creature Get(int id)
		{
			return _ctx.Creatures
				.Include(i => i.Items)
				.ThenInclude(i => i.Item)
				.Include(m => m.MagicBook)
				.Include(w => w.Weapon)
				.Include(a => a.Armor)
				.FirstOrDefault(x => x.Id == id);
		} // Get()
	}
}
