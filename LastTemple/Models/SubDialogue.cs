using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class SubDialogue
	{
		public int Id { get; set; }
		public List<string> Content { get; set; }
		public List<DialogueOption> Options { get; set; }
	}
}

