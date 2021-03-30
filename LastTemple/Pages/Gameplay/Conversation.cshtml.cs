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
	public class ConversationModel : PageModel
	{
		private readonly ApplicationDbContext _ctx;
		public ConversationModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}
		public Dialogue Dialogue { get; set; }		
		public int SubDialogueId { get; set; }

		public void OnGet()
		{			
			Dialogue = DialogueSystem.GetDialogue(DialogueSystem.DialogueId);
			SubDialogueId = DialogueSystem.SubDialogueId;
		}

		public IActionResult OnPostOption(int id)
		{
			DialogueSystem.SetSubDialogue(id, _ctx);

			return RedirectToPage(GameplayManager.GetPhase());
		}
		
	}
}
