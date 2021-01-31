using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum SpellTypeEnum
	{
		[Display(Name ="Bojowe")]
		Offensive, // Damage enemy		
		[Display(Name = "Leczące")]
		Healing // Restore hit points
	}
}
