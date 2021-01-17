using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum CreatureTypeEnum
	{
		Hero, // Player character
		Standard, // Non magical enemy
		Magical, // Enemy fighting primary using spells
		Hybrid // Special enemy using magic and standard attacks
	}
}
