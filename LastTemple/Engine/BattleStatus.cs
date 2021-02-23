using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class BattleStatus
	{
		private static ApplicationDbContext _ctx; 
		public static Creature Hero;
		public static List<Creature> Enemies;
		public static List<Creature> Combatants;


		public static bool AssignHero(int heroId, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Hero = _ctx.Creatures
				.Include(x => x.MagicBook)
				.Include(x => x.Items).ThenInclude(x => x.Item)
				.SingleOrDefault(x => x.Id == heroId);

			if (Hero == null) return false;			

			return true;
		}



		public static void OrderOfBattle()
		{
			Combatants.Add(Hero);
			Combatants.AddRange(Enemies);
			Combatants.OrderBy(x => x.Initiative);
		}

	}
}
