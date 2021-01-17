using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Armor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DamageResistance { get; set; }
		public int MagicResistance { get; set; }
	}
}
