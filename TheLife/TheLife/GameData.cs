using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLife
{
	enum GameType
	{
		NONE,
		Type1,
		Type2,
		Mixed
	}

	class GameData
	{
		public int m;
		public int n;
		public int generationNumber;

		public GameObject[,] currentGeneration;

		public GameType gameType;

		public int game2Minimum;
		public int game2Maximum;

		public GameData()
		{
			m = 20;
			n = 20;
			generationNumber = 0;

			currentGeneration = new GameObject[m, n];
			for (int i = 0; i < m; i++)
				for (int j = 0; j < n; j++)
					currentGeneration[i, j] = new GameObject();
			gameType = GameType.NONE;

			game2Maximum = 3;
			game2Minimum = 2;
		}
	}
}
