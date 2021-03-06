﻿using LastTemple.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class DialogueSystem
	{
		public static int DialogueId { get; set; } = -1;
		public static int SubDialogueId { get; set; } = -1;
		public static List<Dialogue> Dialogues { get; set; }

		public static void PrepareDialogues()
		{
			if (Dialogues == null)
			{
				if (File.Exists(@".\wwwroot\data\dialogues.json"))
				{
					Dialogues = JsonConvert.DeserializeObject<List<Dialogue>>(File.ReadAllText(@".\wwwroot\data\dialogues.json"));
				}

				else
				{
					Dialogues = new List<Dialogue>();
					CreateSampleDialog();
				}
			}
		} // PrepareDialogues()

		public static Dialogue GetDialogue(int dialogueId)
		{
			PrepareDialogues();

			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);

			if (selectedDialogue != null)
			{
				return selectedDialogue;
			}

			else return new Dialogue();
		} // GetDialogue()

		public static SubDialogue GetSubDialogue(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue = new SubDialogue();

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);
			}

			return selectedSubDialogue;

		} // GetSubDialogue()

		public static List<Dialogue> GetDialogues()
		{
			PrepareDialogues();

			return Dialogues;
		}

		public static void SetSubDialogue(int id, ApplicationDbContext ctx)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == DialogueId);

			if (selectedDialogue != null)
			{
				if (selectedDialogue.SubDialogues.Count <= id)
				{
					GameplayManager.NextStep();
					GameplayManager.UpdateStatus(ctx);
				}

				else
				{
					SubDialogueId = id;
				}
			}

			
		} // SetSubDialogue()
		public static void ChooseDialogue(int id)
		{
			DialogueId = id;

			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if (selectedDialogue != null)
			{
				if (selectedDialogue.SubDialogues.Count > 0)
				{
					SubDialogueId = 0;
				} // when changing dialogue change selected subdialogue for 0 index if subdialogues exist

				else
				{
					SubDialogueId = -1;
				}
			}
		} // SetDialogue()		

		public static void ChangeSubDialogue(int dialogueId, char x)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);

			if (selectedDialogue != null)
			{
				if (x == '+')
				{
					if (SubDialogueId < (selectedDialogue.SubDialogues.Count - 1))
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

		#region Create/Add
		public static void CreateDialogue(string name)
		{
			Dialogue dialogue = new Dialogue
			{
				Description = name,
				Id = Dialogues.Count,
				SubDialogues = new List<SubDialogue>()
			};

			dialogue.SubDialogues.Add(new SubDialogue
			{
				Id = 0,
				Content = new List<string>(),
				Options = new List<DialogueOption>()
			});

			dialogue.SubDialogues[0].Content.Add("");
			dialogue.SubDialogues[0].Options.Add(new DialogueOption
			{
				Content = "",
				OptionDestinationId = 0
			});

			Dialogues.Add(dialogue);

			DialogueId = dialogue.Id;
			SubDialogueId = 0;
		} // CreateDialogue()

		public static void CreateSubDialogue(int dialogueId)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);

			if (selectedDialogue != null)
			{
				SubDialogue createdSubDialogue = new SubDialogue { 
				Id = selectedDialogue.SubDialogues.Count(),
				Content = new List<string>(),
				Options = new List<DialogueOption>()				
				};

				createdSubDialogue.Content.Add("");
				createdSubDialogue.Options.Add(new DialogueOption
				{
					Content = "",
					OptionDestinationId = 0
				});

				selectedDialogue.SubDialogues.Add(createdSubDialogue);

				SubDialogueId = (selectedDialogue.SubDialogues.Count() - 1);
			}
		} // CreateSubDialogue()

		public static void AddParagraph(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if (selectedSubDialogue != null)
				{
					selectedSubDialogue.Content.Add("");

					if (SubDialogueId == -1)
					{
						SubDialogueId = 0;
					}
				}
			}
		} // AddParagraph

		public static void AddOption(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if (selectedSubDialogue != null)
				{
					selectedSubDialogue.Options.Add(new DialogueOption());
				}
			}
		} // AddOption()
		#endregion

		#region Edit/Change
		public static void EditDialogueName(int id, string name)
		{
			var dialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if (dialogue != null)
			{
				dialogue.Description = name;
			}

		} // EditDialogueName()

		public static void ChangeDialogueIndex(char x, int id)
		{
			var selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == id);

			if (selectedDialogue != null)
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
		#endregion

		#region Delete
		public static void DeleteDialogue(int dialogueId)
		{
			var selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
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

			if (DialogueId == dialogueId)
			{
				DialogueId = -1;
			}
			else return;

		} // DeleteDialogue()

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
					if (selectedSubDialogue.Content.Count > 1)
					{
						paragraph = selectedSubDialogue.Content[paragraphIndex];

						if (paragraph != null)
						{
							selectedSubDialogue.Content.RemoveAt(paragraphIndex);
						}
					}
					
				}
			}
		} // DeleteParagraph

		public static void DeleteOption(int dialogueId, int subDialogueId, int optionIndex)
		{
			Dialogue selectedDialogue = Dialogues.FirstOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

				if (selectedSubDialogue != null)
				{
					if (selectedSubDialogue.Options.Count() > 1)
					{
						if (optionIndex < selectedSubDialogue.Options.Count() )
						{
							selectedSubDialogue.Options.RemoveAt(optionIndex);
						}
					}
				}
			}
		} // DeleteOption()

		public static void DeleteSubDialogue(int dialogueId, int subDialogueId)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue.SubDialogues.Count() > 1)
			{
				if (selectedDialogue != null)
				{
					selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogueId);

					if (selectedSubDialogue != null)
					{
						selectedDialogue.SubDialogues.Remove(selectedSubDialogue);

						for (int i = 0; i < Dialogues[dialogueId].SubDialogues.Count(); i++)
						{
							Dialogues[dialogueId].SubDialogues[i].Id = i;
						}

						if (Dialogues[dialogueId].SubDialogues.Count > 0)
						{
							SubDialogueId = 0;
						}
					}
				}
			}
		} // DeleteSubDialogue()
		#endregion

		public static void SaveChanges(int dialogueId, SubDialogue subDialogue)
		{
			Dialogue selectedDialogue = Dialogues.SingleOrDefault(x => x.Id == dialogueId);
			SubDialogue selectedSubDialogue;

			if (selectedDialogue != null)
			{
				selectedSubDialogue = selectedDialogue.SubDialogues.FirstOrDefault(x => x.Id == subDialogue.Id);

				if (selectedSubDialogue != null)
				{
					for (int i=0; i < selectedSubDialogue.Content.Count(); i++)
					{
						selectedSubDialogue.Content[i] = subDialogue.Content[i];
					}

					for (int i=0; i < selectedSubDialogue.Options.Count(); i++)
					{
						selectedSubDialogue.Options[i] = subDialogue.Options[i];
					}
				}
			}

			File.WriteAllText(@".\wwwroot\data\dialogues.json", JsonConvert.SerializeObject(Dialogues));

		} // SaveChanges()

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
