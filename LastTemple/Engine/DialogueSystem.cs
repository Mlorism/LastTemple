using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class DialogueSystem
	{

		public static int DialogId { get; set; } = 0;
		public static int SubDialogueId { get; set; }
		public static List<Dialogue> Dialogues { get; set; }

		public static Dialogue GetDialogue()
		{
			if (Dialogues == null)
			{
				Dialogues = new List<Dialogue>();
				CreateSampleDialog();
			}

			return Dialogues[DialogId];
		}

		public static void SetDialogue(int id)
		{
			DialogId = id;
		} // SetDialogue()

		public static void SetSubDialogue(int id)
		{
			SubDialogueId = id;
		} // SetSubDialogue()

		public static void CreateSampleDialog()
		{
			Dialogue Dialogue;

			Dialogue = new Dialogue
			{
				Id = 0,
				SubDialogues = new List<SubDialogue>()
			};

			SubDialogue subDialogue = new SubDialogue
			{
				Id = 0,
				Content = new List<string>(),
				Options = new List<DialogueOption>()
			};

			subDialogue.Content.Add("Przed tobą rozpościera się morze ruin, dotychczas nie widziałeś pozostałości po tak dużym mieście. Poza wiatrem i ponurym krakaniem nic nie słychać. Po chwili dostrzegasz smugę dymu. Postanawiasz zbadać źródło.");
			subDialogue.Content.Add("Gdy zbliżasz się w okolice, z których pochodził dym słyszysz za sobą kroki. Zza rogu wychodzi trzech mężczyzn. Nie wyglądają na tak obdartych jak dotychczas spotkani mieszkańcy pustkowi. Dwóch młodszych dzierży broń. Staruszek podparty na kiju wygląda na przywódcę.");
			subDialogue.Content.Add("");
			subDialogue.Content.Add("-Witaj wędrowcze, widzę, że przybywasz z daleka. Rzadko mamy tutaj gości, zazwyczaj bandytów. Mam nadzieję, że masz pokojowe zamiary. Nie lubimy stosować przemocy, lecz nie zawahamy się, gdy trzeba.");

			DialogueOption option = new DialogueOption
			{
				OptionDestinationId = 1,
				Content = "Witaj. Możecie być spokojni, mam pokojowe zamiary. Nazywam się {imię}. Jak się zwiesz?"
			};

			subDialogue.Options.Add(option);

			option = new DialogueOption
			{
				OptionDestinationId = 1,
				Content = "Jeśli nie zostanę sprowokowany nie dojdzie do rozlewu krwii. Kim jesteście?"
			};

			subDialogue.Options.Add(option);

			option = new DialogueOption
			{
				OptionDestinationId = 1,
				Content = "Na tym świecie niczego nie można być pewnym. Równie dobrze i wy możecie być bandytami. Więc proszę się nie zbliżać. Co tu robicie?"
			};

			subDialogue.Options.Add(option);

			Dialogue.SubDialogues.Add(subDialogue);

			////////////////////////////////////////////

			subDialogue = new SubDialogue
			{
				Id = 1,
				Content = new List<string>(),
				Options = new List<DialogueOption>()
			};

			subDialogue.Content.Add("xxxx");

			option = new DialogueOption
			{
				OptionDestinationId = 0,
				Content = "xxx 1"
			};

			subDialogue.Options.Add(option);

			option = new DialogueOption
			{
				OptionDestinationId = 0,
				Content = "xxx 2"
			};

			subDialogue.Options.Add(option);

			option = new DialogueOption
			{
				OptionDestinationId = 0,
				Content = "xxx 3"
			};

			subDialogue.Options.Add(option);



			Dialogue.SubDialogues.Add(subDialogue);





			Dialogues.Add(Dialogue);
		}
	}
}
