using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLife
{
	public delegate void PauseHandler();

	interface IInterface
	{
		event PauseHandler PauseEvent;

		string MainMenu();

		GameType NewGameMenu();

		void LoadGameMenu();

		void PauseMenu(out bool isEnded, out bool isSaveNeeded);

		void SaveMenu();

		void PrintGeneration(GameData gameData);

		void EndGameMenu(GameData gameData);
	}
}
