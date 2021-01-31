using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LastTemple.Enumerators
{
	public static class EnumConverter
	{
		public static string Result(Enum value)
		{
			return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
		}

	}
}
