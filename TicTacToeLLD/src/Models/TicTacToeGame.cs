using TicTacToeLLD.src.Factories;
using TicTacToeLLD.src.Strategies;

namespace TicTacToeLLD.src.Models
{
	public class TicTacToeGame
	{
        public TicTacToeGame(Player player1, Player player2, IWinningStrategy winningStrategy, int size)
        {
            this.board = new Cell[size, size];
            this.player1 = player1;
            this.player2 = player2;
            this.CurrentPlayer = player1;
            this.Winner = null;
            this.winningStrategy = winningStrategy;

            // Initialize the game board with empty cells
            for (int row = 0; row < board.GetLength(0); row++)
                for (int col = 0; col < board.GetLength(1); col++)
                    board[row, col] = CellFactory.CreateCell();
        }

        private readonly Cell[,] board;
		private Player player1;
		private Player player2;
        private IWinningStrategy winningStrategy;

        public Player CurrentPlayer { get; private set; }
        public Player? Winner { get; private set; }

        public void MakeMove(int row, int col)
        {
            if (row < 0 || row > board.GetLength(0) || col < 0 || col > board.GetLength(1) || board[row, col].Symbol != ' ')
                return;

            board[row, col].SetSymbol(CurrentPlayer.Symbol);
            CheckForWinner();
            SwitchPlayer();
        }

        public void CheckForWinner()
        {
            if (winningStrategy.CheckForWinner(board, CurrentPlayer.Symbol))
                Winner = CurrentPlayer;
        }

        public bool IsDraw()
        {
            if (Winner != null)
                return false;

            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c].Symbol == ' ')
                        return false;

            return true;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == player1) ? player2 : player1;
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current Board:");
            Console.WriteLine("-------------");

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                    Console.Write($"| {board[row, col].Symbol} ");
                Console.WriteLine("|");
                Console.WriteLine("-------------");
            }
        }
    }
}

