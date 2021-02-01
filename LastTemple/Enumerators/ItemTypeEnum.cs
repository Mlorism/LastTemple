using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public enum ItemTypeEnum
	{
		[Display(Name = "Leczenie")]
		Healing, // for example, a bandage
		[Display(Name = "Mana")]
		Mana, // for example, a magic powder
		[Display(Name ="Siła")]
		StrengthBooster, // for example, a ring
		[Display(Name = "Wytrzymałość")]
		EnduranceBooster, // for example, a talisman
		[Display(Name = "Wola")]
		WillpowerBooster, // for example, a bracelet
		[Display(Name = "Szybkość")]
		SpeedBooster, // for example, a ribbon, boots
		[Display(Name = "Zręczność")]
		AgilityBooster // for example, a gloves
	}
}
