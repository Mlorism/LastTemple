using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class CreatureItem
	{				
		public int CreatureId { get; set; }		
		public int ItemId { get; set; }
		public int Qty { get; set; }

		public virtual Creature Creature { get; set; }
		public virtual Item Item { get; set; }
	}
}
