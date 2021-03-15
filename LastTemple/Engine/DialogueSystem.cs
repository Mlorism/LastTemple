using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class DialogueSystem
	{

		public static int DialogueId { get; set; } = -1;
		public static int SubDialogueId { get; set; } = -1;
		public static List<Dialogue> Dialogues { get; set; }

		public static Dialogue GetDialogue()
		{
			if (Dialogues == null)
			{
				Dialogues = new List<Dialogue>();
				CreateSampleDialog();
			}

			return Dialogues[DialogueId];
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
		public static void ChooseDialogue(int id)
		{
			DialogueId = id;

			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if (selectedDialogue != null)
			{
				if(selectedDialogue.SubDialogues.Count > 0)
				{
					SetSubDialogue(0);
				} // when changing dialogue change selected subdialogue for 0 index if subdialogues exist
			}
		} // SetDialogue()

		public static void SetSubDialogue(int id)
		{
			SubDialogueId = id;
		} // SetSubDialogue()

		public static void ChangeSubDialogue(int dialogueId, char x)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);

			if(selectedDialogue != null)
			{
				if (x == '+')
				{
					if (SubDialogueId < (selectedDialogue.SubDialogues.Count-1))
					{
						SubDialogueId++;
					}
				}

				else if (x == '-')
				{
					if (SubDialogueId > 0)
					{
						SubDialogueId--;
					}
				}
			}
		} // ChangeDialogue

		public static void CreateDialogue(string name)
		{
			Dialogue dialogue = new Dialogue
			{
				Description = name,
				Id = Dialogues.Count,
				SubDialogues = new List<SubDialogue>()
			};

			Dialogues.Add(dialogue);			
		} // CreateDialogue()

		public static void EditDialogueName(int id, string name)
		{
			var dialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if(dialogue != null)
			{
				dialogue.Description = name;
			}

		} // EditDialogueName()

		public static void DeleteDialogue(int id)
		{
			var selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == id);
			if (selectedDialogue != null)
			{
				Dialogues.Remove(selectedDialogue);
				
				if (Dialogues.Count > 0)
				{
					for (int i = 0; i < Dialogues.Count; i++)
					{
						Dialogues[i].Id = i;
					}
				}
			}

			if (DialogueId == id)
			{
				DialogueId = -1;
			}
			else return;

		} // DeleteDialogue()

		public static void ChangeDialogueIndex(char x, int id)
		{
			var selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if(selectedDialogue != null)
			{
				if (x == '+')
				{
					if (((Dialogues.Count - 1) > id) && (Dialogues.Count > 1))
					{
						for (int i = 0; i < Dialogues.Count; i++)
						{
							if (i == id || i == (id + 1))
							{
								if (Dialogues[i].Id == id)
								{
									Dialogues[i].Id++;
								}

								else 
								{
									Dialogues[i].Id--;
								}
							} // change id only for dialogues with equal to selected dialogue id and next
						} // for()
					} // change id only for dialogues with smaller id than max id and if there is more dialogues than 1
				}


				else if (x == '-')
				{
					if ((0 < id) && (Dialogues.Count > 1))
					{
						for (int i = 0; i < Dialogues.Count; i++)
						{
							if (i == id || i == (id - 1))
							{
								if (Dialogues[i].Id == id)
								{
									Dialogues[i].Id--;
								}

								else
								{
									Dialogues[i].Id++;
								}
							} // change id only for dialogues with equal to selected dialogue id and previous
						} // for()
					} // change id only for dialogues with bigger id than 0 and if there is more dialogues than 1
				}

				else return;

				Dialogues = Dialogues.OrderBy(x => x.Id).ToList();				
			}
		} // ChangeDialogueIndex()

		public static void AddParagraph(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if(selectedSubDialogue != null)
				{
					selectedSubDialogue.Content.Add("");
				}
			}
		} // AddParagraph

		public static void DeleteParagraph(int dialogueId, int subDialogueId, int paragraphIndex)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;
			string paragraph;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if (selectedSubDialogue != null)
				{
					paragraph = selectedSubDialogue.Content[paragraphIndex];

					if (paragraph != null)
					{
						selectedSubDialogue.Content.RemoveAt(paragraphIndex);
					}
				}
			}
		} // DeleteParagraph

		public static void AddOption(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if(selectedSubDialogue != null)
				{
					selectedSubDialogue.Options.Add(new DialogueOption());
				}
			}
		} // AddOption()

		public static void DeleteOption(int dialogueId, int subDialogueId, int optionIndex)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;			

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if (selectedSubDialogue != null)
				{
					if (optionIndex < selectedSubDialogue.Options.Count)
					{
						selectedSubDialogue.Options.RemoveAt(optionIndex);
					}
				}
			}
		} // DeleteOption()










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
