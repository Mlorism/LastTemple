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

			await _ctx.SaveChangesAsync();

			CalculateCreature.DerivedStatistics(creature, _ctx);

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


			await _ctx.SaveChangesAsync();

			CalculateCreature.DerivedStatistics(creature, _ctx);

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

			await _ctx.SaveChangesAsync();

			CalculateCreature.DerivedStatistics(creature, _ctx);

			return true;
		} // UpdateInventory() updates only creature's inventory

		public async Task<bool> UpdateWeapon(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			if (target.Weapon == null) target.Weapon = new Weapon();
			
			target.Weapon.Name = creature.Weapon.Name;
			target.Weapon.BaseDamage = creature.Weapon.BaseDamage;
			target.Weapon.MagicDamage = creature.Weapon.MagicDamage;
			target.Weapon.ActionCost = creature.Weapon.ActionCost;
			target.Weapon.HitChance = creature.Weapon.HitChance;

			await _ctx.SaveChangesAsync();			

			return true;
		} // UpdateWeapon() updates only creature's weapon

		public async Task<bool> UpdateArmor(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			if (target.Armor == null) target.Armor = new Armor();

			target.Armor.Name = creature.Armor.Name;
			target.Armor.DamageResistance = creature.Armor.DamageResistance;
			target.Armor.MagicResistance = creature.Armor.MagicResistance;

			await _ctx.SaveChangesAsync();

			CalculateCreature.DerivedStatistics(creature, _ctx);

			return true;
		} // UpdateArmor() updates only creature's armor

		public async Task<bool> AddItem(Creature creature, int itemId)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Item item = _ctx.Items.Find(itemId);
			if (item == null) return false;

			if (target.Items == null) target.Items = new List<Item>();

			target.Items.Add(item);					

			await _ctx.SaveChangesAsync();

			CalculateCreature.ItemsEffect(creature, _ctx);

			return true;
		} // AddItem()

		public async Task<bool> DeleteItem(Creature creature, int itemId)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Item item = target.Items.FirstOrDefault(x => x.Id == itemId);
			if (item.Id != itemId) return false;

			Item buffer = target.Items.FirstOrDefault(x => x.Id == itemId);
			if (buffer.Id != itemId) return false;

			target.Items.Remove(item);

			await _ctx.SaveChangesAsync();

			CalculateCreature.ItemsEffect(creature, _ctx);

			return true;
		} // DeleteItem()

		public async Task<bool> AddSpell(Creature creature, int spellId)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Spell spell = _ctx.Spells.Find(spellId);
			if (spell == null) return false;

			if (target.MagicBook == null) target.MagicBook = new List<Spell>();

			target.MagicBook.Add(spell);

			await _ctx.SaveChangesAsync();

			return true;
		} // AddSpell()

		public async Task<bool> DeleteSpell(Creature creature, int spellId)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Spell spell = _ctx.Spells.Find(spellId);
			if (spell == null) return false;

			Spell buffer = target.MagicBook.FirstOrDefault(x => x.Id == spellId);
			if (buffer.Id != spellId) return false;

			target.MagicBook.Remove(spell);

			await _ctx.SaveChangesAsync();
			
			return true;
		} // DeleteSpell()
	}
}
