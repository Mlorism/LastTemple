using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Models
{
	public class LocationMark
	{
		public string Name { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
		public bool Discovered { get; set; }
		public int Destination { get; set; }
	}
}
