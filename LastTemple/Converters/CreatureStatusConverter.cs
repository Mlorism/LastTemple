using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Converters
{
	public static class CreatureStatusConverter
	{
		public static string Status(Creature target)
		{
			double healthRemaining = (double)(target.HitPoints) / (double)(target.MaxHP);

			if (healthRemaining == 1)
			{
				return "W pełni sił";
			}

			else if (healthRemaining > 0.8)
			{
				return "Lekko ranny";
			}

			else if (healthRemaining > 0.5)
			{
				return "Ranny";
			}

			else if (healthRemaining > 0.2)
			{
				return "Ciężko ranny";
			}

			else if (healthRemaining > 0)
			{
				return "Prawie martwy";
			}

			else
			{
				return "Martwy";
			}			
				
		}
	}
}
