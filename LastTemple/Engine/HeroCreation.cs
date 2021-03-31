using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class HeroCreation
	{
		private static ApplicationDbContext _ctx;
		public static void Create(string name, int strenght, int weakness, int weapon, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature Hero = new Creature
			{
				Name = name,
				Type = Enumerators.CreatureTypeEnum.Hero,
				Level = 0,
				Experience = 10,
				Alive = true,
				Strength = 8,
				Endurance = 8,
				Willpower = 8,
				Speed = 8,
				Agility = 8,
				Weapon = new Weapon(),
				Armor = _ctx.Armors.FirstOrDefault(x => x.Id == 29),
				MagicBook = new List<Spell>(),
				Items = new List<CreatureItem>()
			};

			switch (strenght)
			{
				case 0:
					Hero.Strength += 2;
					break;
				case 1:
					Hero.Endurance += 2;
					break;
				case 2:
					Hero.Willpower += 2;
					break;
				case 3:
					Hero.Speed += 2;
					break;
				case 4:
					Hero.Agility += 2;				
					break;
			} // switch (strenght)

			switch (weakness)
			{
				case 0:
					Hero.Strength -= 1;
					break;
				case 1:
					Hero.Endurance -= 1;
					break;
				case 2:
					Hero.Willpower -= 1;
					break;
				case 3:
					Hero.Speed -= 1;
					break;
				case 4:
					Hero.Agility -= 1;
					break;
			} // switch (weakness)

			switch (weapon)
			{
				case 0:
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 5); 
					break;
				case 1:
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 39);
					break;
				case 2:
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 12);
					break;
			} // switch (weapon)


			Hero.MagicBook.Add(_ctx.Spells.First(x => x.Id == 1));
			Hero.MagicBook.Add(_ctx.Spells.First(x => x.Id == 2));

			_ctx.Creatures.Add(Hero);
			_ctx.SaveChanges();

			Hero = _ctx.Creatures.Include(x => x.Items).OrderBy(x => x.Id).LastOrDefault();
			Item item = _ctx.Items.FirstOrDefault(x => x.Id == 1);

			Hero.Items.Add(new CreatureItem
			{
				CreatureId = Hero.Id,
				ItemId = item.Id,
				Qty = 3,

				Creature = Hero,
				Item = item
			}); 

			_ctx.SaveChanges();

			CalculateCreature.DerivedStatistics(Hero, _ctx);		

			BattleStatus.AssignHero(Hero.Id, _ctx);

		} // Create()
	}
}
