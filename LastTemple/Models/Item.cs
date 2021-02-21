using LastTemple.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Item
	{		
		public int Id { get; set; }
		public string Name { get; set; }
		public ItemTypeEnum ItemType { get; set; }
		public int Strength { get; set; }
		public int ActionCost { get; set; }
		public virtual ICollection<CreatureItem> Creatures { get; set; }
	}
}
