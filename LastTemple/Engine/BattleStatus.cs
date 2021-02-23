using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class BattleStatus
	{
		public static Creature Hero;
		public static List<Creature> Enemies;
		public static List<Creature> Combatants;

		public static void OrderOfBattle()
		{
			Combatants.Add(Hero);
			Combatants.AddRange(Enemies);
			Combatants.OrderBy(x => x.Initiative);
		}

	}
}
