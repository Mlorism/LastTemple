using LastTemple.Engine;
using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
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
			target.Items = new List<CreatureItem>();

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
				target.Items.Add(new CreatureItem
				{
					CreatureId = item.CreatureId,
					ItemId = item.ItemId,
					Qty = item.Qty,

					Creature = item.Creature,
					Item = item.Item
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

			if (creature.Weapon != null)
			{
				var weapon = creature.Weapon;
				target.Weapon = weapon;				
			}

			if (creature.Armor != null)
			{
				var armor = creature.Armor;
				target.Armor = armor;
			}
			target.MagicBook = new List<Spell>();
			target.Items = new List<CreatureItem>();

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
				target.Items.Add(new CreatureItem
				{
					CreatureId = item.CreatureId,
					ItemId = item.ItemId,
					Qty = item.Qty,

					Creature = item.Creature,
					Item = item.Item
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

			var weapon = creature.Weapon;

			if (target.Weapon == null) target.Weapon = weapon;			

			await _ctx.SaveChangesAsync();			

			return true;
		} // UpdateWeapon() updates only creature's weapon

		public async Task<bool> UpdateArmor(Creature creature)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);

			if (target == null) return false;

			var armor = creature.Armor;

			if (target.Armor == null) target.Armor = armor;			

			await _ctx.SaveChangesAsync();

			CalculateCreature.DerivedStatistics(creature, _ctx);

			return true;
		} // UpdateArmor() updates only creature's armor

		public async Task<bool> AddItem(Creature creature, int itemId)
		{
			Creature target = _ctx.Creatures.Include(x => x.Items).FirstOrDefault(x => x.Id == creature.Id);
			if (target == null) return false;

			Item item = _ctx.Items.Find(itemId);
			if (item == null) return false;

			if (target.Items == null) target.Items = new List<CreatureItem>();

			if(target.Items.SingleOrDefault(x => x.ItemId == itemId) == null)
			{
				target.Items.Add(new CreatureItem
				{
					CreatureId = target.Id,
					ItemId = item.Id,
					Qty = 1,

					Creature = creature,
					Item = item
				});
			}
			
			else
			{
				target.Items.FirstOrDefault(x => x.ItemId == itemId).Qty++;
			}

			await _ctx.SaveChangesAsync();

			CalculateCreature.ItemsEffect(creature, _ctx);

			return true;
		} // AddItem()

		public async Task<bool> ChangeItemQty(Creature creature, int itemId, int qty)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Item item = _ctx.Items.Find(itemId);
			if (item == null) return false;

			if (target.Items.SingleOrDefault(x => x.ItemId == itemId) == null)
				return false;

			target.Items.SingleOrDefault(x => x.ItemId == itemId).Qty = qty;

			await _ctx.SaveChangesAsync();

			return true;

		} // ChangeItemQty()

		public async Task<bool> DeleteItem(Creature creature, int itemId)
		{
			Creature target = _ctx.Creatures.Find(creature.Id);
			if (target == null) return false;

			Item item = _ctx.Items.Find(itemId);
			if (item == null) return false;

			if (target.Items.FirstOrDefault(x => x.ItemId == itemId) == null)
				return false;

			target.Items.Remove(target.Items.FirstOrDefault(x => x.ItemId == itemId));

			await _ctx.SaveChangesAsync();

			CalculateCreature.ItemsEffect(creature, _ctx);

			return true;
		} // DeleteItem()

		
		public async Task<bool> AddSpell(Creature creature, int spellId)
		{
			Creature target = _ctx.Creatures.Include(x => x.MagicBook).SingleOrDefault(x => x.Id == creature.Id);
			if (target == null) return false;

			Spell spell = _ctx.Spells.Find(spellId);
			if (spell == null) return false;			

			if (target.MagicBook == null) target.MagicBook = new List<Spell>();

			if (target.MagicBook.SingleOrDefault(x => x.Id == spellId) != null)
				return false;

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

			if(target.MagicBook.SingleOrDefault(x => x.Id == spellId) == null)
				return false;

			target.MagicBook.Remove(spell);

			await _ctx.SaveChangesAsync();
			
			return true;
		} // DeleteSpell()
	}
}
