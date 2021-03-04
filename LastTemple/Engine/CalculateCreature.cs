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
			
			target.MaxHP = 15 + (target.Strength + target.Endurance * 2) * (target.Level + 1);
			target.HitPoints = 15 + (target.Strength + target.Endurance * 2) * (target.Level + 1);
			target.MaxMana = 4 + target.Willpower * (target.Level + 1);
			target.Mana = 4 + target.Willpower * (target.Level + 1);
			target.MaxAP = 5 + (int)Math.Floor(target.Speed / 2.0);
			target.ActionPoints = 5 + (int)Math.Floor(target.Speed / 2.0);

			if (creature.Armor != null)
			{
				target.DamageResistance = creature.Armor.DamageResistance + target.Endurance;
				target.MagicResistance = creature.Armor.MagicResistance + target.Endurance;
			}

			else if (target.Armor != null)
			{
				target.DamageResistance = target.Armor.DamageResistance + target.Endurance;
				target.MagicResistance = target.Armor.MagicResistance + target.Endurance;
			}

			else
			{
				target.DamageResistance = target.Endurance;
				target.MagicResistance = target.Endurance;
			}

			target.Initiative = target.Speed + target.Agility;

			_ctx.SaveChanges();

			return true;
		} // DerivedStatistics()

		public static bool ItemEffect(Creature creature, ApplicationDbContext ctx, int ItemId)
		{
			_ctx = ctx;

			Creature target = _ctx.Creatures.Include(x => x.Items).ThenInclude(x => x.Item).SingleOrDefault(x => x.Id == creature.Id);

			if (target == null) return false;

			Item item = _ctx.Items.SingleOrDefault(x => x.Id == ItemId);
			if (item == null) return false;

			if (target.Items.SingleOrDefault(x => x.ItemId == ItemId) != null)
			{
				if (item.ItemType == Enumerators.ItemTypeEnum.AgilityBooster) { target.Agility += item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.EnduranceBooster) { target.Endurance += item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.SpeedBooster) { target.Speed += item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.StrengthBooster) { target.Strength += item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.WillpowerBooster) { target.Willpower += item.Strength; }
			}

			else
			{
				if (item.ItemType == Enumerators.ItemTypeEnum.AgilityBooster) { target.Agility -= item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.EnduranceBooster) { target.Endurance -= item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.SpeedBooster) { target.Speed -= item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.StrengthBooster) { target.Strength -= item.Strength; }
				if (item.ItemType == Enumerators.ItemTypeEnum.WillpowerBooster) { target.Willpower -= item.Strength; }
			}

			_ctx.SaveChanges();

			DerivedStatistics(creature, ctx);

			return true;
		} // ItemsEffect()

	}
}
