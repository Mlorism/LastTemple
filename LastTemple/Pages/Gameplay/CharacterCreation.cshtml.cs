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
		public string Name { get; set; }
		public void OnGet()
		{
		}

		public IActionResult OnPostName()
		{
			return RedirectToPage("CharacterCreation");
		}
	}
}
