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
		public CreatureTypeEnum Type { get; set; } // defines fighting style
		public int Level { get; set; } // affects the number of experience points given to a winner
		public bool Alive { get; set; }

		#region Attributes
		public int Strength { get; set; } // strength is used to calculate damage dealt using primary weapon
										  // can be increased as the character level up
		public int Endurance { get; set; } // endurance is used to calculate max HitPoints and DamageResistance
										   // can be increased as the character level up
		public int Willpower { get; set; } // willpower is used to calculate max Mana
										   // can be increased as the character level up
		public int Speed { get; set; } // speed is used to calculate ActionPoints and Initiative
									   // the upper limit is 10 and cannot be changed even after level up, only by modifiers / events
		public int Agility { get; set; } // agility is used to calculate chance to doge, hit and Initiative
										 // the upper limit is 10 and cannot be changed even after level up, only by modifiers / events
		#endregion

		#region Derived statistics
		public int HitPoints { get; set; } // derived from Endurance, Strength and Level
		public int Mana { get; set; } // derived from Willpower and Level
		public int ActionPoints { get; set; } // derived from Speed
		public int BaseDamage { get; set; } // derived from Weapon and Strength		
		public int DamageResistance { get; set; } // derived from Endurance and equipped armor or natural hide/shell => property Armor
		public int MagicResistance { get; set; } // derived from Willpower and equipped armor or natural hide/shell => property Armor
		public int Initiative { get; set; } // derived from Speed and Agility
		#endregion

		#region Inventory
		public Weapon Weapon { get; set; }
		public Armor Armor { get; set; }
		public List<Spell> MagicBook { get; set; }
		public List<Item> Items { get; set; }

		#endregion
	}
}
