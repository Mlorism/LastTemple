using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum ItemTypeEnum
	{
		[Display(Name = "Leczące")]
		Healing, // for example, a bandage

		Mana, // for example, a magic powder

		StrengthBooster, // for example, a ring

		EnduranceBooster, // for example, a talisman

		WillpowerBooster, // for example, a bracelet

		SpeedBooster, // for example, a ribbon, boots

		AgilityBooster // for example, a gloves
	}
}
