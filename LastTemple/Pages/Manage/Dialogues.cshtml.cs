using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.Engine;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Manage
{
	public class DialoguesModel : PageModel
	{
		public List<Dialogue> Dialogues { get; set; }
		public void OnGet()
		{
			Dialogues = DialogueSystem.GetDialogues();
		}
	}
}
