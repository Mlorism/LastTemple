using LastTemple.Enumerators;
using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class GameplayManager
	{
		public static GamePhase Phase { get; set; } = GamePhase.CharacterCreation;
		public static int Step { get; set; } = 0;
		public static string GetPhase()
		{
			return Phase.ToString();
		} // GetPhase()

		public static void NextStep()
		{
			Step++;
		} // NextStep()

		public static void UpdateStatus(ApplicationDbContext ctx)
		{
			switch (Step)
			{
				case 0:
					DialogueSystem.PrepareDialogues();
					DialogueSystem.ChooseDialogue(0);
					Phase = GamePhase.Conversation;
					break;

				case 1:
					BattleStatus.AddEnemy(1039, ctx);
					BattleStatus.AddEnemy(1039, ctx);					

					BattleStatus.PrepareBattle();
					Phase = GamePhase.BattleField;
					break;

				case 2:

					Phase = GamePhase.BattleField;
					break;

				case 3:

					break;

				case 4:

					break;

				case 5:

					break;

				case 6:

					break;
			} // switch()
		} // UpdateStatus()




	}
}
