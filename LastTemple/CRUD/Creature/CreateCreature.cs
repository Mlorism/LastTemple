using LastTemple.Engine;
using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.CRUD
{
	public class CreateCreature
	{
		private readonly ApplicationDbContext _ctx;

		public CreateCreature(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<bool> Create(Creature creature)
		{
			Creature target = new Creature
			{
				Name = creature.Name,
				Type = creature.Type,
				Level = creature.Level,
				Experience = creature.Experience,
				Supplies = creature.Supplies,
				Alive = true,

				Strength = creature.Strength,
				Endurance = creature.Endurance,
				Willpower = creature.Willpower,
				Speed = creature.Speed,
				Agility = creature.Agility,				

				MagicBook = new List<Spell>(),
				Items = new List<Item>()				
			};

			if(creature.Weapon != null) 
			{
				target.Weapon = new Weapon
				{
					Name = creature.Weapon.Name,
					BaseDamage = creature.Weapon.BaseDamage,
					MagicDamage = creature.Weapon.MagicDamage,
					ActionCost = creature.Weapon.ActionCost,
					HitChance = creature.Weapon.HitChance
				};
			}

			if (creature.Armor != null)
			{
				target.Armor = new Armor
				{
					Name = creature.Armor.Name,
					DamageResistance = creature.Armor.DamageResistance,
					MagicResistance = creature.Armor.MagicResistance
				};
			}

			if (creature.MagicBook != null)
			{

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
			}

			if (creature.Items != null)
			{
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
			}

			CalculateCreature.DerivedStatistics(creature, _ctx);

			_ctx.Creatures.Add(target);

			await _ctx.SaveChangesAsync();

			return true;
		} // Create()
	}
}
