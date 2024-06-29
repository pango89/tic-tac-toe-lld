using System;
using TicTacToeLLD.src.Models;

namespace TicTacToeLLD.src.Factories
{
	public class PlayerFactory
	{
		public static Player CreatePlayer(string name, char symbol)
		{
			return new Player(name, symbol);
		}
	}
}

