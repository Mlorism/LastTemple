using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
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

			Creature target = _ctx.Creatures.Include(x => x.Items).SingleOrDefault(x => x.Id == creature.Id);

			if (target == null) return false;
			
			if(target.Items == null) return false;

			foreach(var item in target.Items)
			{
				if(item.Item.ItemType == Enumerators.ItemTypeEnum.AgilityBooster) { target.Agility += item.Item.Strength; }
				if(item.Item.ItemType == Enumerators.ItemTypeEnum.EnduranceBooster) { target.Endurance += item.Item.Strength; }
				if(item.Item.ItemType == Enumerators.ItemTypeEnum.SpeedBooster) { target.Speed += item.Item.Strength; }
				if(item.Item.ItemType == Enumerators.ItemTypeEnum.StrengthBooster) { target.Strength += item.Item.Strength; }
				if(item.Item.ItemType == Enumerators.ItemTypeEnum.WillpowerBooster) { target.Willpower += item.Item.Strength; }
			}

			_ctx.SaveChanges();

			return true;
		} // ItemsEffect()

	}
}
