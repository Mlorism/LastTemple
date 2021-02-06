using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum CreatureTypeEnum
	{
		[Display(Name = "Bohater")]
		Hero, // Player character
		[Display(Name = "Zwykły")]
		Standard, // Non magical enemy
		[Display(Name = "Magiczny")]
		Magical, // Enemy fighting primary using spells
		[Display(Name = "Hybrydowy")]
		Hybrid // Special enemy using magic and standard attacks
	}
}
