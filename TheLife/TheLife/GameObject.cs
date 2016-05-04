using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLife
{
	public enum GameObjectType
	{
		NoObject,
		Grass1,
		Grass2		
	}


	class GameObject
	{
		private GameObjectType type;
		public GameObjectType Type 
		{
			get { return type; }
			set
			{
				type = value;
				switch (value)
				{
					case GameObjectType.NoObject: Symbol = ' '; break;
					case GameObjectType.Grass1: Symbol = '0'; break;
					case GameObjectType.Grass2: Symbol = 'Ф'; break;
				}
			}
		}
		public char Symbol { get; private set; }

		public GameObject()
		{
			Type = GameObjectType.NoObject;
		}

		public GameObject(GameObjectType type)
		{
			Type = type;
		}
	}
}
