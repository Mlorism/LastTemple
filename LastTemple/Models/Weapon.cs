using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Weapon
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Damage { get; set; }
		public int MagicDamage { get; set; }
		public int ActionCost { get; set; }
		public int HitChance { get; set; }
	}
}
