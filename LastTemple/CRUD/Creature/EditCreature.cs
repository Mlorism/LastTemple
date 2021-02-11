using LastTemple.Engine;
using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class EditCreature
	{
		private readonly ApplicationDbContext _ctx;

		public EditCreature(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> UpdateFull(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			target.Name = creature.Name;
			target.Type = creature.Type;
			target.Level = creature.Level;
			target.Experience = creature.Experience;
			target.Supplies = creature.Supplies;

			target.Strength = creature.Strength;
			target.Endurance = creature.Endurance;
			target.Willpower = creature.Willpower;
			target.Speed = creature.Speed;
			target.Agility = creature.Agility;					
			
			target.Weapon.Name = creature.Weapon.Name;
			target.Weapon.BaseDamage = creature.Weapon.BaseDamage;
			target.Weapon.MagicDamage = creature.Weapon.MagicDamage;
			target.Weapon.ActionCost = creature.Weapon.ActionCost;
			target.Weapon.HitChance = creature.Weapon.HitChance;
			
			target.Armor.Name = creature.Armor.Name;
			target.Armor.DamageResistance = creature.Armor.DamageResistance;
			target.Armor.MagicResistance = creature.Armor.MagicResistance;

			target.MagicBook = new List<Spell>();
			target.Items = new List<Item>();

			foreach (var spell in creature.MagicBook)
			{
				target.MagicBook.Add(new Spell
				{
					Name = spell.Name,
					Type = spell.Type,
					Level = spell.Level,
					ManaCost = spell.ManaCost,
					ActionCost = spell.ActionCost,
					Strength = spell.Strength
				});
			}

			foreach (var item in creature.Items)
			{
				target.Items.Add(new Item
				{
					Name = item.Name,
					ItemType = item.ItemType,
					Strength = item.Strength,
					ActionCost = item.ActionCost
				});
			}

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateFull() updates creature's parameters and inventory

		public async Task<bool> UpdateCreature(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			target.Name = creature.Name;
			target.Type = creature.Type;
			target.Level = creature.Level;
			target.Experience = creature.Experience;
			target.Supplies = creature.Supplies;

			target.Strength = creature.Strength;
			target.Endurance = creature.Endurance;
			target.Willpower = creature.Willpower;
			target.Speed = creature.Speed;
			target.Agility = creature.Agility;


			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateCreature() updates only creature's parameters

		public async Task<bool> UpdateInventory(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			if (target.Weapon != null)
			{
				target.Weapon.Name = creature.Weapon.Name;
				target.Weapon.BaseDamage = creature.Weapon.BaseDamage;
				target.Weapon.MagicDamage = creature.Weapon.MagicDamage;
				target.Weapon.ActionCost = creature.Weapon.ActionCost;
				target.Weapon.HitChance = creature.Weapon.HitChance;
			}

			if (target.Armor != null)
			{
				target.Armor.Name = creature.Armor.Name;
				target.Armor.DamageResistance = creature.Armor.DamageResistance;
				target.Armor.MagicResistance = creature.Armor.MagicResistance;
			}
			target.MagicBook = new List<Spell>();
			target.Items = new List<Item>();

			foreach (var spell in creature.MagicBook)
			{
				target.MagicBook.Add(new Spell
				{
					Name = spell.Name,
					Type = spell.Type,
					Level = spell.Level,
					ManaCost = spell.ManaCost,
					ActionCost = spell.ActionCost,
					Strength = spell.Strength
				});
			}

			foreach (var item in creature.Items)
			{
				target.Items.Add(new Item
				{
					Name = item.Name,
					ItemType = item.ItemType,
					Strength = item.Strength,
					ActionCost = item.ActionCost
				});
			}

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateInventory() updates only creature's inventory

		public async Task<bool> UpdateWeapon(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;
			
			target.Weapon.Name = creature.Weapon.Name;
			target.Weapon.BaseDamage = creature.Weapon.BaseDamage;
			target.Weapon.MagicDamage = creature.Weapon.MagicDamage;
			target.Weapon.ActionCost = creature.Weapon.ActionCost;
			target.Weapon.HitChance = creature.Weapon.HitChance;

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateInventory() updates only creature's inventory

		public async Task<bool> UpdateArmor(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;			
			
			target.Armor.Name = creature.Armor.Name;
			target.Armor.DamageResistance = creature.Armor.DamageResistance;
			target.Armor.MagicResistance = creature.Armor.MagicResistance;

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateInventory() updates only creature's inventory

		public async Task<bool> UpdateItems(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;		
			
			target.Items = new List<Item>();			

			foreach (var item in creature.Items)
			{
				target.Items.Add(new Item
				{
					Name = item.Name,
					ItemType = item.ItemType,
					Strength = item.Strength,
					ActionCost = item.ActionCost
				});
			}

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateInventory() updates only creature's inventory

		public async Task<bool> UpdateSpells(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			target.MagicBook = new List<Spell>();			

			foreach (var spell in creature.MagicBook)
			{
				target.MagicBook.Add(new Spell
				{
					Name = spell.Name,
					Type = spell.Type,
					Level = spell.Level,
					ManaCost = spell.ManaCost,
					ActionCost = spell.ActionCost,
					Strength = spell.Strength
				});
			}

			CalculateCreature.DerivedStatistics(creature, _ctx);

			await _ctx.SaveChangesAsync();

			return true;
		} // UpdateInventory() updates only creature's inventory
	}
}
