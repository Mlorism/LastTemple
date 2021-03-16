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
		[BindProperty]
		public List<Dialogue> Dialogues { get; set; } = new List<Dialogue>();
		[BindProperty]
		public string DialogueName { get; set; }
		[BindProperty]
		public int DialogueId { get; set; }
		[BindProperty]
		public int SubDialogueId { get; set; }
		[BindProperty]
		public SubDialogue SubDialogue { get; set; }
		public void OnGet()
		{
			Dialogues = DialogueSystem.GetDialogues();
			DialogueId = DialogueSystem.DialogueId;
			SubDialogueId = DialogueSystem.SubDialogueId;
			SubDialogue = DialogueSystem.GetSubDialogue(DialogueId, SubDialogueId);
		}
		public IActionResult OnPostCreateDialogue()
		{
			DialogueSystem.CreateDialogue(DialogueName);

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostChooseDialogue()
		{
			DialogueSystem.ChooseDialogue(DialogueId);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostEditName()
		{
			DialogueSystem.EditDialogueName(DialogueId, DialogueName);

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostDeleteDialogue()
		{
			if (DialogueId != -1) 
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

		public IActionResult OnPostNextSubDialogue()
		{
			DialogueSystem.ChangeSubDialogue(DialogueId, '+');

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostPreviousSubDialogue()
		{
			DialogueSystem.ChangeSubDialogue(DialogueId, '-');

			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostDeleteParagraph(int paragraphIndex)
		{
			DialogueSystem.DeleteParagraph(DialogueId, SubDialogueId, paragraphIndex);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostAddParagraph()
		{
			DialogueSystem.AddParagraph(DialogueId, SubDialogueId);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostAddOption()
		{
			DialogueSystem.AddOption(DialogueId, SubDialogueId);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostDeleteOption(int optionIndex)
		{
			DialogueSystem.DeleteOption(DialogueId, SubDialogueId, optionIndex);
			return RedirectToPage("Dialogues");
		}
		
		public IActionResult OnPostDeleteSubDialogue()
		{			
			DialogueSystem.DeleteSubDialogue(DialogueId, SubDialogueId);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostAddSubdialogue()
		{
			DialogueSystem.CreateSubDialogue(DialogueId);
			return RedirectToPage("Dialogues");
		}

		public IActionResult OnPostSaveChanges()
		{		
			DialogueSystem.SaveChanges(DialogueId, SubDialogue);
			return RedirectToPage("Dialogues");
		}





	}
}
