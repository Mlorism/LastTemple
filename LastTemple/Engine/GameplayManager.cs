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
					BattleStatus.PrepareBattle(ctx);

					Phase = GamePhase.BattleField;
					break;

				case 2:
					DialogueSystem.ChooseDialogue(1);

					Phase = GamePhase.Conversation;
					break;

				case 3:
					BattleStatus.AddEnemy(1039, ctx);
					BattleStatus.AddEnemy(1039, ctx); // zmiana na grubego szczura?
					BattleStatus.AddEnemy(1039, ctx);
					BattleStatus.PrepareBattle(ctx);

					Phase = GamePhase.BattleField;
					break;

				case 4:
					DialogueSystem.ChooseDialogue(2);

					Phase = GamePhase.Conversation;
					break;

				case 5:
					Phase = GamePhase.Map;
					break;

				case 6:

					break;

				case 7:

					break;

				case 8:

					break;

				case 9:

					break;

				case 10:

					break;

				case 11:

					break;

				case 12:

					break;

				case 13:

					break;

				case 14:

					break;

				case 15:

					break;
			} // switch()
		} // UpdateStatus()




	}
}
