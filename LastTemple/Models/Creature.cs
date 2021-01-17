using LastTemple.Enumerators;
using LastTemple.Models;
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
		public CreatureTypeEnum Type { get; set; }

		#region Attributes
		public int Strength { get; set; } // can be increased as the character level up
		public int Endurance { get; set; } // can be increased as the character level up
		public int Willpower { get; set; } // can be increased as the character level up
		public int Speed { get; set; } // the upper limit is 10 and cannot be changed even after level up, only by modifiers / events
		public int Agility { get; set; } // the upper limit is 10 and cannot be changed even after level up, only by modifiers / events
		#endregion

		#region Derived statistics
		public int HitPoints { get; set; } // Derived from Endurance and Strength
		public int Mana { get; set; } // Derived from Willpower
		public int ActionPoints { get; set; } // Derived from Speed
		public int BaseDamage { get; set; } // Derived from Weapon
		public int DogeChance { get; set; } // Derived from Agility
		public int DamageResistance { get; set; } // Derived from Endurance and equipped armor or natural hide/shell => property Armor
		public int MagicResistance { get; set; } // Derived from Willpower and equipped armor or natural hide/shell => property Armor
		public int Initiative { get; set; } // Derived from Speed and Agility
		#endregion

		#region Inventory
		public Weapon Weapon { get; set; }
		public Armor Armor { get; set; }
		public List<Spell> Spells { get; set; }
		#endregion
	}
}
