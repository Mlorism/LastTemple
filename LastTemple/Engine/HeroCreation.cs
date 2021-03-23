using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public class HeroCreation
	{
		private static ApplicationDbContext _ctx;
		public void Create(string name, int strenght, int weakness, int weapon)
		{
			Creature Hero = new Creature
			{
				Name = name,
				Strength = 8 //9?
			};

			switch(strenght)
			{
				case 0:

					break;
			} 


			// calculateCreature 

		} // Create
	}
}
