using LastTemple.Models;
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
			Creature Hero = new Creature
			{
				Name = name,
				Type = Enumerators.CreatureTypeEnum.Hero,
				Level = 0,
				Experience = 0,
				Alive = true,
				Strength = 8,
				Endurance = 8,
				Willpower = 8,
				Speed = 8,
				Agility = 8,
				Weapon = new Weapon(),
				Armor = new Armor(),
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
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 0); // ??
					break;
				case 1:
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 0); // ??
					break;
				case 2:
					Hero.Weapon = _ctx.Weapons.FirstOrDefault(x => x.Id == 0); // ??
					break;
			}


			// add spells
			// add items
			// calculateCreature 
			// add to database

			BattleStatus.AssignHero(Hero.Id, _ctx);

		} // Create
	}
}
