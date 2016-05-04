using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheLife
{
	class Game
	{
		private bool isPaused;
		private bool isEnded;

		private GameData gameData;

		private IInterface interf;


		public void Start(IInterface i)
		{
			interf = i;
			string choise;
			do
			{
				isPaused = false;
				isEnded = false;
				choise = interf.MainMenu();
				if (choise == "new game")
				{
					GameType type = interf.NewGameMenu();
					interf.PauseEvent += PauseEventHandler;
					NewGame(type);
					interf.PauseEvent -= PauseEventHandler;
				}
				if (choise == "load game")
				{
					interf.LoadGameMenu();
					interf.PauseEvent += PauseEventHandler;
					interf.PauseEvent -= PauseEventHandler;
				}
			}
			while (choise != "esc");
		}

		private void NewGame(GameType type)
		{
			switch (type)
			{
				case GameType.Type1: Generate1(); break;
				case GameType.Type2: Generate2(); break;
				case GameType.Mixed: GenerateMixed(); break;
				case GameType.NONE: return;
			}
			gameData.gameType = type;
			Play();
		}


		private void Generate1()
		{
			/*var r = new Random();
			for (int i = 0; i < gameData.currentGeneration.GetLength(0); i++)
				for (int j = 0; j < gameData.currentGeneration.GetLength(1); j++)
				{
					int rr = (r.Next() % 2) * (r.Next() % 2) * (r.Next() % 2);
					if(rr == 1)
						gameData.currentGeneration[i,j] = new GameObject(GameObjectType.Grass1);
 					else
						gameData.currentGeneration[i,j] = new GameObject(GameObjectType.NoObject);
				}*/
			gameData = new GameData();

			gameData.currentGeneration[1, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 4].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 5].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[2, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[2, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 2].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 7].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[4, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[4, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[5, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[5, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 2].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 7].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[7, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[7, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 4].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 5].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 6].Type = GameObjectType.Grass1;
		}
		private void Generate2()
		{
			gameData = new GameData();

			gameData.currentGeneration[5, 5].Type = GameObjectType.Grass2;
			gameData.currentGeneration[5, 6].Type = GameObjectType.Grass2;
			gameData.currentGeneration[4, 5].Type = GameObjectType.Grass2;
		}
		private void GenerateMixed()
		{
			gameData = new GameData();

			gameData.currentGeneration[1, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 4].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 5].Type = GameObjectType.Grass1;
			gameData.currentGeneration[1, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[2, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[2, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 2].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 7].Type = GameObjectType.Grass1;
			gameData.currentGeneration[3, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[4, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[4, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[5, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[5, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 1].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 2].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 7].Type = GameObjectType.Grass1;
			gameData.currentGeneration[6, 8].Type = GameObjectType.Grass1;
			gameData.currentGeneration[7, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[7, 6].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 3].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 4].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 5].Type = GameObjectType.Grass1;
			gameData.currentGeneration[8, 6].Type = GameObjectType.Grass1;

			gameData.currentGeneration[12, 12].Type = GameObjectType.Grass2;
			gameData.currentGeneration[12, 13].Type = GameObjectType.Grass2;
			gameData.currentGeneration[11, 12].Type = GameObjectType.Grass2;
		}

		private void Play()
		{
			Random r = new Random();

			GameObject[,] newGeneration = new GameObject[gameData.m, gameData.n];
			for (int i = 0; i < gameData.m; i++)
				for (int j = 0; j < gameData.n; j++)
					newGeneration[i, j] = new GameObject(gameData.currentGeneration[i, j].Type);

			do
			{
				gameData.generationNumber++;

				Console.Clear();
				interf.PrintGeneration(gameData);

				GetNewGeneration(r, newGeneration);

				if (EqualGenerations(newGeneration))
					isEnded = true;

				for (int i = 0; i < gameData.m; i++)
					for (int j = 0; j < gameData.n; j++)
						gameData.currentGeneration[i, j].Type = newGeneration[i, j].Type;

				Thread.Sleep(500);

				while (isPaused)
					Thread.Sleep(1000);
			}
			while (!isEnded);
			EndGame();
		}

		private bool EqualGenerations(GameObject[,] newGeneration)
		{
			for(int i = 0; i< gameData.m; i++)
				for(int j = 0; j<gameData.n; j++)
					if(newGeneration[i,j].Type != gameData.currentGeneration[i,j].Type)
						return false;
			return true;
		}

		private void EndGame()
		{
			interf.EndGameMenu(gameData);
		}
		

		private void GetNewGeneration(Random r, GameObject[,] newGeneration)
		{
			for (int i = 0; i < gameData.m; i++)
				for (int j = 0; j < gameData.n; j++)
				{
					int neighbors = NeighborsNumber(i, j);

					if (gameData.gameType != GameType.Type2 && gameData.currentGeneration[i, j].Type == GameObjectType.NoObject)
					{
						if (neighbors == 3)
						{
							newGeneration[i, j].Type = GameObjectType.Grass1;
						}
					}

					else if (gameData.currentGeneration[i, j].Type == GameObjectType.Grass1)
					{
						if (neighbors < 2 || neighbors > 3)
							newGeneration[i, j].Type = GameObjectType.NoObject;
					}

					else if (gameData.currentGeneration[i, j].Type == GameObjectType.Grass2)
						if (neighbors > gameData.game2Maximum)
							newGeneration[i, j].Type = GameObjectType.NoObject;
						else if (neighbors >= gameData.game2Minimum && neighbors <= gameData.game2Maximum)
						{
							List<GameObject> neighborsList = GetNeighbors(newGeneration, i, j);
							int l = r.Next(neighborsList.Count());
							neighborsList[l].Type = GameObjectType.Grass2;
						}

				}
		}

		int NeighborsNumber(int i, int j)
		{
			int neighbors = 0;
			int m = gameData.m;
			int n = gameData.n;

			if (i == 0)
				if (j == 0)
					neighbors += NeighborsNumberPlusor(m - 1, 0, 1, n - 1, 0, 1);
				else if (j == n - 1)
					neighbors += NeighborsNumberPlusor(m - 1, 0, 1, n - 2, n - 1, 0);
				else
					neighbors += NeighborsNumberPlusor(m - 1, 0, 1, j - 1, j, j + 1);
			else if (i == m - 1)
			{
				if (j == 0)
					neighbors += NeighborsNumberPlusor(m - 2, m - 1, 0, n - 1, 0, 1);
				else if (j == n - 1)
					neighbors += NeighborsNumberPlusor(m - 2, m - 1, 0, n - 2, n - 1, 0);
				else
					neighbors += NeighborsNumberPlusor(m - 2, m - 1, 0, j - 1, j, j + 1);
			}
			else
			{
				if (j == 0)
					neighbors += NeighborsNumberPlusor(i - 1, i, i + 1, n - 1, 0, 1);
				else if (j == n - 1)
					neighbors += NeighborsNumberPlusor(i - 1, i, i + 1, n - 2, n - 1, 0);
				else
					neighbors += NeighborsNumberPlusor(i - 1, i, i + 1, j - 1, j, j + 1);
			}
			return neighbors;
		}
		private int NeighborsNumberPlusor(int i1, int i2, int i3, int j1, int j2, int j3)
		{
			int n = 0;
			if (gameData.currentGeneration[i1, j1].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i1, j2].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i1, j3].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i2, j1].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i2, j3].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i3, j1].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i3, j2].Type != GameObjectType.NoObject)
				n++;
			if (gameData.currentGeneration[i3, j3].Type != GameObjectType.NoObject)
				n++;
			return n;
		}

		private List<GameObject> GetNeighbors(GameObject[,] newGeneration, int i, int j)
		{
			List<GameObject> neighborsList = new List<GameObject>();
			int m = gameData.m;
			int n = gameData.n;

			if (i == 0)
				if (j == 0)
					GetNeighborsAdder(neighborsList, newGeneration, m - 1, 0, 1, n - 1, 0, 1);
				else if (j == n - 1)
					GetNeighborsAdder(neighborsList, newGeneration, m - 1, 0, 1, n - 2, n - 1, 0);
				else
					GetNeighborsAdder(neighborsList, newGeneration, m - 1, 0, 1, j - 1, j, j + 1);
			else if (i == m - 1)
			{
				if (j == 0)
					GetNeighborsAdder(neighborsList, newGeneration, m - 2, m - 1, 0, n - 1, 0, 1);
				else if (j == n - 1)
					GetNeighborsAdder(neighborsList, newGeneration, m - 2, m - 1, 0, n - 2, n - 1, 0);
				else
					GetNeighborsAdder(neighborsList, newGeneration, m - 2, m - 1, 0, j - 1, j, j + 1);
			}
			else
			{
				if (j == 0)
					GetNeighborsAdder(neighborsList, newGeneration, i - 1, i, i + 1, n - 1, 0, 1);
				else if (j == n - 1)
					GetNeighborsAdder(neighborsList, newGeneration, i - 1, i, i + 1, n - 2, n - 1, 0);
				else
					GetNeighborsAdder(neighborsList, newGeneration, i - 1, i, i + 1, j - 1, j, j + 1);
			}
			return neighborsList;

		}
		private void GetNeighborsAdder(List<GameObject> neighborsList, GameObject[,] newGeneration, int i1, int i2, int i3, int j1, int j2, int j3)
		{
			if (gameData.currentGeneration[i1, j1].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i1, j1]);
			if (gameData.currentGeneration[i1, j2].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i1, j2]);
			if (gameData.currentGeneration[i1, j3].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i1, j3]);
			if (gameData.currentGeneration[i2, j1].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i2, j1]);
			if (gameData.currentGeneration[i2, j3].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i2, j3]);
			if (gameData.currentGeneration[i3, j1].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i3, j1]);
			if (gameData.currentGeneration[i3, j2].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i3, j2]);
			if (gameData.currentGeneration[i3, j3].Type == GameObjectType.NoObject)
				neighborsList.Add(newGeneration[i3, j3]);
		}


		private void SaveGame()
		{
			throw new NotImplementedException();
		}

		private void PauseEventHandler()
		{
			isPaused = true;
			bool isSaveNeeded = false;
			interf.PauseMenu(out isEnded, out isSaveNeeded);

			if (isSaveNeeded)
				SaveGame();
			isPaused = false;
		}
	}
}
