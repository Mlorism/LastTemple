using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple
{
	public class Creature
	{
		public int Id { get; set; }
		public string Name { get; set; }

		#region Attributes
		public int Strength { get; set; }
		public int Endurance { get; set; }
		public int Willpower { get; set; }
		public int Speed { get; set; }
		public int Agility { get; set; }
		#endregion

		#region Derived statistics
		public int HitPoints { get; set; } // Derived from Endurance and Strength
		public int Mana { get; set; } // Derived from Willpower
		public int ActionPoints { get; set; } // Derived from Speed
		public int DogeChance { get; set; } // Derived from Agility
		public int DamageResistance { get; set; } // Derived from Endurance
		public int MagicResistance { get; set; } // Derived from Willpower
		public int ArmorClass { get; set; } // Derived from equipped armor or natural hide/shell
		public int Initiative { get; set; } // Derived from Speed and Agility
		#endregion
	}
}
