using TicTacToeLLD.src.Factories;
using TicTacToeLLD.src.Models;
using TicTacToeLLD.src.Strategies;

public class Program
{
    public static void Main(string[] args)
    {
        Player player1 = PlayerFactory.CreatePlayer("Piku", 'X');
        Player player2 = PlayerFactory.CreatePlayer("Monu", 'O');

        TicTacToeGame game = new TicTacToeGame(player1, player2, new DefaultWinningStrategy(), 3);

        Console.WriteLine("Welcome to Tic Tac Toe!");
        Console.WriteLine("Player 1 (X) vs. Player 2 (O)\n");

        while(true)
        {
            Console.Clear();
            game.PrintBoard();

            Console.WriteLine($"{game.CurrentPlayer.Name}'s turn ({game.CurrentPlayer.Symbol}):");

            Console.Write("Enter row (0, 1, or 2): ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter column (0, 1, or 2): ");
            int col = int.Parse(Console.ReadLine());

            game.MakeMove(row, col);

            if (game.IsDraw())
            {
                Console.Clear();
                game.PrintBoard();
                Console.WriteLine("It's a draw!");

                Console.Write("Press 9 and Enter to play again: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 9)
                {
                    game = new TicTacToeGame(player1, player2, new DefaultWinningStrategy(), 3);
                }
                else
                {
                    break;
                }
            }

            if (game.Winner != null)
            {
                Console.Clear();
                game.PrintBoard();
                Console.WriteLine($"{game.Winner.Name} wins!");


                Console.Write("Press 9 and Enter to play again: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 9)
                {
                    game = new TicTacToeGame(player1, player2, new DefaultWinningStrategy(), 3);
                }
                else
                {
                    break;
                }
            }
        }
    }
}