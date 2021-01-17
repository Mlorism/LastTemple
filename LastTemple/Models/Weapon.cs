using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Weapon
	{
		public int Id { get; set; }
		public int Name { get; set; }
		public int BaseDamage { get; set; }
		public int BaseActionCost { get; set; }
		public int BaseHitChance { get; set; }
	}
}
