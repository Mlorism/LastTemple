using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class CalculateCreature
	{
		public static void DerivedStatistics(Creature target)
		{
			target.MaxHP = 15 + (target.Strength + target.Endurance * 2) * target.Level;
			target.HitPoints = target.MaxHP;
			target.MaxMana = 4 + target.Willpower * target.Level;
			target.Mana = target.MaxMana;
			target.ActionPoints = 0;
			target.BaseDamage = 0;
			target.DamageResistance = 0;
			target.MagicResistance = 0;
			target.Initiative = 0;

		}
	}
}
