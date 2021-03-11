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

		public static List<Dialogue> GetDialogues()
		{
			if (Dialogues == null)
			{
				Dialogues = new List<Dialogue>();
				CreateSampleDialog();
			}

			return Dialogues;
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
				Description = "Przybycie do Teb",
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


			//////////////////////////////////////////////////////////////////////////////////

			Dialogue = new Dialogue
			{
				Id = 1,
				Description = "Ruiny Troi",
				SubDialogues = new List<SubDialogue>()
			};

			subDialogue = new SubDialogue
			{
				Id = 0,
				Content = new List<string>(),
				Options = new List<DialogueOption>()
			};

			subDialogue.Content.Add("Po dwóch trzech wędrówki górskimi szlakami i zarośniętymi drogami docierasz do opuszczonej osady. Te zabudowania, które jeszcze stoją zostały przechylone przez upływ czasu. W centralnej części dostrzegasz pozostałości największego z budynków. Między murowanymi fundamentami wyrosło wysokie drzewo rozpościerające cień na okolicę.");
			subDialogue.Content.Add("Obecny stan wsi utrudnia orientację mimo szkicu z planem, który otrzymałeś wyruszając na misję. Wygląda na to, że Rak'ha bogini natury odzyskuje co niegdyś zabrał człowiek.");
			subDialogue.Content.Add("Na pewno jesteś w dobrej lokalizacji. Położenie rzeki, a także gór i czas podróży się zgadzają z odczytami z dużej mapy. To musi być Troja. Problemem jest odnalezienie krypty. Zastanawiasz się co zrobić teraz?");
			subDialogue.Content.Add("");

			option = new DialogueOption
			{
				OptionDestinationId = 1,
				Content = "To drzewo może być dobrym punktem widokowym. Spróbuj się na nie wspiąć."
			};

			subDialogue.Options.Add(option);

			option = new DialogueOption
			{
				OptionDestinationId = 2,
				Content = "Masz szkic osady, spróbuj znaleźć punkty orientacyjne i dopasować do rysunku."
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

			subDialogue.Content.Add("Nigdy wcześniej nie wspinałeś się na drzewo. Wychowanie w podziemnej krypcie pozbawiło cię doświadczeń przeciętnego dziecka sprzed Ciszy. Z jednej strony jest to doświadczenie ekscytujące, ale z drugiej inne uczucie zaczyna dawać o sobie znać. Nie wiesz jak je nazwać, lecz to po prostu strach przed wysokością. Wspinasz się coraz wolniej i coraz mocniej ściskasz gałęzie. Każda złamana zmusza do przerwy by uspokoić nerwy.");
			subDialogue.Content.Add("W końcu po długim czasie docierasz na szczyt, z którego widać całą okolicę i o wiele dalej. Strach przestrzeni walczy w tobie z ciekawością i fascynacją. Emocje nie pozwalają jasno myśleć.");
			subDialogue.Content.Add("Po dłuższej chwili przypominasz sobie co robisz w koronie drzewa. Im dłużej analizujesz zabudowania, tym bardziej dociera do Ciebie niedokładność szkicu. Jednak bez problemów identyfikujesz najbardziej charakterystyczne punkty.");
			subDialogue.Content.Add("Krypta najduje się w lokalnym kościele. Budynek powinien znajdować się wewnątrz Troi. Jednak na skutek rozpadu zabudowań jego ruiny stoją na wzgórzu tuż za pozostałościami miejscowości.");
			subDialogue.Content.Add("");

			option = new DialogueOption
			{
				OptionDestinationId = 0,
				Content = "Zejdź z drzewa. Nie będzie to takie proste, ale nie masz wyjścia. Kierujesz się w stronę kościoła."
			};

			subDialogue.Options.Add(option);

			Dialogue.SubDialogues.Add(subDialogue);

			////////////////////////////////////////////

			subDialogue = new SubDialogue
			{
				Id = 2,
				Content = new List<string>(),
				Options = new List<DialogueOption>()
			};

			subDialogue.Content.Add("Im dłużej analizujesz szkic osady tym widzisz więcej nieścisłości. Większość z domów to musiały być liche chaty, które bez napraw poddały się kornikom i pogodzie. Teraz po nich pozostały fragmenty zbutwiałych belek, które pokrywa mech lub przykryła trawa.");
			subDialogue.Content.Add("Budynek z murowanymi fundamentami został zbudowany najsolidniej. Skoro tak, należał do kogoś ważnego. W tej sytuacji to musi być dom wójta, który na szczęście jest oznaczony na rysunku. Teraz należy zidentyfikować pozostałe.");
			subDialogue.Content.Add("Odszukanie punktów orientacyjnych trochę zajmuje, ale w końcu wiesz jak ustawić szkic, a więc i gdzie powinna leżeć krypta. Według zapisków wejście do niej znajduje się wewnątrz kościoła. Gdy spoglądasz we właściwy kierunku dostrzegasz niewielkie wzgórze, na szczycie, którego widać ostre, nienaturalne kontury.");
			subDialogue.Content.Add("");
			
			option = new DialogueOption
			{
				OptionDestinationId = 0,
				Content = "Odkładasz pergamin i kierujesz się w stronę kościoła."
			};

			subDialogue.Options.Add(option);

			Dialogue.SubDialogues.Add(subDialogue);

			////////////////////////////////////////////

			Dialogues.Add(Dialogue);
		}
	}
}
