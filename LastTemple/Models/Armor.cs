using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Armor
	{
		[Key]
		public int Id { get; set; }
		
		[StringLength(20, MinimumLength = 3)]
		[Required]
		public string Name { get; set; }
		[Required]
		public int DamageResistance { get; set; }
		[Required]
		public int MagicResistance { get; set; }
	}
}
