using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.Engine;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Gameplay
{
	public class MapModel : PageModel
	{
		[BindProperty]
		public List<LocationMark> Locations { get; set; }
		public void OnGet()
		{
			Locations = MapManager.GetLocations();
		}





	}
}
