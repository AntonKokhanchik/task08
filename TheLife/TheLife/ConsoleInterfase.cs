using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLife
{
	class ConsoleInterfase : IInterface
	{
		public event PauseHandler PauseEvent;

		public string MainMenu()
		{
			ConsoleKey ch;

			Console.Clear();
			PrintMainMenu();

			do
			{
				ch = Console.ReadKey(true).Key;
			}
			while
				(ch != ConsoleKey.D1 &&
				ch != ConsoleKey.D2 &&
				ch != ConsoleKey.NumPad1 &&
				ch != ConsoleKey.NumPad2 &&
				ch != ConsoleKey.Escape);

			switch (ch)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1: return "new game";
				case ConsoleKey.D2:
				case ConsoleKey.NumPad2: return "load game";
			}
			return "esc";
		}

		private void PrintMainMenu()
		{
			Console.WriteLine("1. начать новую игру");
			Console.WriteLine("2. загрузить игру");
			Console.WriteLine("Esc для выхода");
		}

		public GameType NewGameMenu()
		{
			Console.Clear();
			PrintNewGameMenu();
			ConsoleKey ch;

			do
			{
				ch = Console.ReadKey(true).Key;
			}
			while
				(ch != ConsoleKey.D1 &&
				ch != ConsoleKey.D2 &&
				ch != ConsoleKey.D3 &&
				ch != ConsoleKey.NumPad1 &&
				ch != ConsoleKey.NumPad2 &&
				ch != ConsoleKey.NumPad3 &&
				ch != ConsoleKey.Escape);

			switch (ch)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1: return GameType.Type1;
				case ConsoleKey.D2:
				case ConsoleKey.NumPad2: return GameType.Type2;
				case ConsoleKey.D3:
				case ConsoleKey.NumPad3: return GameType.Mixed;
			}
			return GameType.NONE;
		}
		private void PrintNewGameMenu()
		{
			Console.WriteLine("1. начать новую по первым правилам");
			Console.WriteLine("2. начать новую по вторым правилам");
			Console.WriteLine("3. начать новую по смешанным правилам");
		}

		public void LoadGameMenu()
		{
			throw new NotImplementedException();
		}

		public void PauseMenu(out bool isEnded, out bool isSaveNeeded)
		{
			char ch;
			Console.WriteLine("Завершить игру(д/н)?");
			isEnded = false;
			isSaveNeeded = false;
			do
			{
				ch = Console.ReadKey(true).KeyChar;
			}
			while (ch != 'д' && ch != 'н');

			if (ch == 'д')
			{
				Console.WriteLine("Сохранить игру(д/н)?");
				do
				{
					ch = Console.ReadKey(true).KeyChar;
				}
				while (ch != 'д' && ch != 'н');

				if (ch == 'д')
					isSaveNeeded = true;

				isEnded = true;
			}
		}
		public void CancelKeyPressHandler(object sender, ConsoleCancelEventArgs e)
		{
			e.Cancel = true;
			var ev = PauseEvent;
			if (ev != null)
				ev();
		}

		public void SaveMenu()
		{
			throw new NotImplementedException();
		}

		public void PrintGeneration(GameData gameData)
		{
			for (int i = 0; i < gameData.m; i++)
			{
				for (int j = 0; j < gameData.n; j++)
					Console.Write("{0}", gameData.currentGeneration[i, j].Symbol);
				Console.Write("\n");
			}
			Console.WriteLine("Поколение {0}", gameData.generationNumber);
		}

		public void EndGameMenu(GameData gameData)
		{
			Console.Clear();
			Console.WriteLine("Игра завершена:\n\n");
			PrintGeneration(gameData);

		}
	}

}
