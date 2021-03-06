﻿using LastTemple.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class Spell
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public SpellTypeEnum Type { get; set; }
		public int Level { get; set; } // Level requirement
		public int ManaCost { get; set; }
		public int ActionCost { get; set; }
		public int Strength { get; set; } // Damage for offensice and restore for healing
		public ICollection<Creature> Creatures { get; set; }
	}
}
