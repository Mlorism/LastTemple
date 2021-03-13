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
		[BindProperty]
		public string DialogueName { get; set; }
		[BindProperty]
		public int DialogueId { get; set; } = -1;
		public void OnGet()
		{
			Dialogues = DialogueSystem.GetDialogues();
		}

		public IActionResult OnPostCreateDialogue()
		{
			DialogueSystem.CreateDialogue(DialogueName);

			return RedirectToPage("Dialogues");
		}
		public IActionResult OnPostEditName()
		{
			DialogueSystem.EditDialogueName(DialogueId, DialogueName);

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostDeleteDialogue()
		{
			if(DialogueId != -1) 
			{ 
				DialogueSystem.DeleteDialogue(DialogueId); 
			}		

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostIncreaseDialogueIndex()
		{
			if (DialogueId != -1)
			{
				DialogueSystem.ChangeDialogueIndex('+', DialogueId);
			}
				
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostDecreaseDialogueIndex()
		{
			if (DialogueId != -1)
			{
				DialogueSystem.ChangeDialogueIndex('-', DialogueId);
			}
			return RedirectToPage("Dialogues");
		}
	}
}
