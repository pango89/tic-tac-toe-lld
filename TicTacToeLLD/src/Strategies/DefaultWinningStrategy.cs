using System;
using TicTacToeLLD.src.Models;

namespace TicTacToeLLD.src.Strategies
{
    public class DefaultWinningStrategy : IWinningStrategy
    {
        public bool CheckForWinner(Cell[,] board, char symbol)
        {
            return CheckRows(board, symbol) || CheckColumns(board, symbol) || CheckDiagonals(board, symbol);
        }

        private static bool CheckRows(Cell[,] board, char symbol)
        {
            int R = board.GetLength(0);

            for (int r = 0; r < R; r++)
                if (IsRowComplete(board, r, symbol))
                    return true;

            return false;
        }

        private static bool CheckColumns(Cell[,] board, char symbol)
        {
            int C = board.GetLength(1);

            for (int c = 0; c < C; c++)
                if (IsColumnComplete(board, c, symbol))
                    return true;

            return false;
        }

        private static bool CheckDiagonals(Cell[,] board, char symbol)
        {
            return IsMainDiagonalComplete(board, symbol) || IsCrossDiagonalComplete(board, symbol);
        }

        private static bool IsRowComplete(Cell[,] board, int row, char symbol)
        {
            int C = board.GetLength(1);

            for (int c = 0; c < C; c++)
                if (board[row, c].Symbol != symbol)
                    return false;

            return true;
        }

        private static bool IsColumnComplete(Cell[,] board, int col, char symbol)
        {
            int R = board.GetLength(0);

            for (int r = 0; r < R; r++)
                if (board[r, col].Symbol != symbol)
                    return false;

            return true;
        }

        private static bool IsMainDiagonalComplete(Cell[,] board, char symbol)
        {
            int R = board.GetLength(0);

            for (int i = 0; i < R; i++)
                if (board[i, i].Symbol != symbol)
                    return false;

            return true;
        }

        private static bool IsCrossDiagonalComplete(Cell[,] board, char symbol)
        {
            int R = board.GetLength(0);

            for (int i = 0; i < R; i++)
                if (board[i, R - 1 - i].Symbol != symbol)
                    return false;

            return true;
        }
    }
}

