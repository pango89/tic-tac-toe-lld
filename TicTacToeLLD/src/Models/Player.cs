using System;
namespace TicTacToeLLD.src.Models
{
	public class Player
	{
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; private set; }
        public char Symbol { get; private set; }
    }
}

