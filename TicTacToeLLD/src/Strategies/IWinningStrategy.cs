using TicTacToeLLD.src.Models;
namespace TicTacToeLLD.src.Strategies
{
	public interface IWinningStrategy
	{
		bool CheckForWinner(Cell[,] board, char symbol);
	}
}

