using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum SpellTypeEnum
	{
		Offensive, // Damage enemy
		Defensive, // Increase armor class
		Blessing, // Temporary increase attributes and derived statistics
		Curse, // Temporary decrease attributes and derived statistics
		Healing // Restore hit points
	}
}
