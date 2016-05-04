using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLife
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleInterfase i = new ConsoleInterfase();
			Console.CancelKeyPress += i.CancelKeyPressHandler;
			Game g = new Game();
			g.Start(i);
		}
	}
}
