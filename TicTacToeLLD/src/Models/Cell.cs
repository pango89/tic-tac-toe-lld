using System;
namespace TicTacToeLLD.src.Models
{
	public class Cell
	{
        public Cell()
        {
            Symbol = ' ';
        }

        public char Symbol { get; private set; }

        public void SetSymbol(char symbol)
        {
            if (Symbol == ' ')
            {
                Symbol = symbol;
            }
            else
            {
                Console.WriteLine("Cell already contains Symbol {0}", Symbol);
            }
        }
	}
}

