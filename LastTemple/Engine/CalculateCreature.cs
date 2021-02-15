using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class CalculateCreature
	{
		private static ApplicationDbContext _ctx;

		public static bool DerivedStatistics(Creature creature, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature target = _ctx.Creatures.Find(creature.Id);	

			if (target == null) return false;
			
			target.MaxHP = 15 + (creature.Strength + creature.Endurance * 2) * creature.Level;
			target.HitPoints = creature.MaxHP;
			target.MaxMana = 4 + creature.Willpower * creature.Level;
			target.Mana = creature.MaxMana;			
			target.ActionPoints = 5 + (int)Math.Floor(creature.Speed / 2.0);

			if(creature.Armor != null)
			{
				target.DamageResistance = creature.Armor.DamageResistance + creature.Endurance;
				target.MagicResistance = creature.Armor.MagicResistance + creature.Endurance;
			}

			else
			{
				target.DamageResistance = creature.Endurance;
				target.MagicResistance = creature.Endurance;
			}

			target.Initiative = creature.Speed + creature.Agility;

			_ctx.SaveChanges();

			return true;
		} // DerivedStatistics()

		public static bool ItemsEffect(Creature creature, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;


			////
			////
			////
			

			return true;
		} // ItemsEffect()

	}
}
