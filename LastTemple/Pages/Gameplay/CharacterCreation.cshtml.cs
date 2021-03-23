using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Gameplay
{
	public class CharacterCreation : PageModel
	{
		[BindProperty]		
		public string Name { get; set; }
		[BindProperty]
		public int selectedStrength { get; set; }
		[BindProperty]
		public int selectedWeakness { get; set; }
		[BindProperty]
		public int selectedWeapon { get; set; }
		public void OnGet()
		{

		}

		public IActionResult OnPostCreateHero()
		{
			return RedirectToPage("CharacterCreation");
		}
	}
}
