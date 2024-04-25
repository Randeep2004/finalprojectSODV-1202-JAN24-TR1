using System;

public class ConnectFour
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;
    private char[,] board;
    private char currentPlayer;
    private bool isSinglePlayer;
    private Random random;

    public ConnectFour(bool singlePlayer)
    {
        board = new char[ROWS, COLUMNS];
        currentPlayer = 'X';
        isSinglePlayer = singlePlayer;
        random = new Random();
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                board[i, j] = 0;
            }
        }
    }

    public void PrintBoard()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool DropPiece(int column)
    {
        for (int i = ROWS - 1; i >= 0; i--)
        {
            if (board[i, column] == 0)
            {
                board[i, column] = currentPlayer;
                return true;
            }
        }
        return false; // Column is full
    }

    public bool CheckWin()
    {
        // Check horizontally  yr
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS - 3; j++)
            {
                if (board[i, j] == currentPlayer && board[i, j + 1] == currentPlayer &&
                    board[i, j + 2] == currentPlayer && board[i, j + 3] == currentPlayer)
                {
                    return true;
                }
            }
        }

        // Check vertically
        for (int i = 0; i < ROWS - 3; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                if (board[i, j] == currentPlayer && board[i + 1, j] == currentPlayer &&
                    board[i + 2, j] == currentPlayer && board[i + 3, j] == currentPlayer)
                {
                    return true;
                }
            }
        }

        // Check diagonally (top-left to bottom-right)
        for (int i = 0; i < ROWS - 3; i++)
        {
            for (int j = 0; j < COLUMNS - 3; j++)
            {
                if (board[i, j] == currentPlayer && board[i + 1, j + 1] == currentPlayer &&
                    board[i + 2, j + 2] == currentPlayer && board[i + 3, j + 3] == currentPlayer)
                {
                    return true;
                }
            }
        }

        // Check diagonally (top-right to bottom-left)
        for (int i = 0; i < ROWS - 3; i++)
        {
            for (int j = 3; j < COLUMNS; j++)
            {
                if (board[i, j] == currentPlayer && board[i + 1, j - 1] == currentPlayer &&
                    board[i + 2, j - 2] == currentPlayer && board[i + 3, j - 3] == currentPlayer)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsDraw()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                if (board[i, j] == 0)
                {
                    return false; //The Board is not full
                }
            }
        }
        return true; //The Board is full
    }

    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 1 ? 2 : 1;
    }

    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ConnectFour game = new ConnectFour();
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            game.PrintBoard();
            Console.WriteLine($"Player {game.GetCurrentPlayer()}'s turn.");

            int column;
            do
            {
                Console.Write("Enter column (0-6): ");
            } while (!int.TryParse(Console.ReadLine(), out column) || column < 0 || column > 6);

            if (game.DropPiece(column))
            {
                if (game.CheckWin())
                {
                    Console.Clear();
                    game.PrintBoard();
                    Console.WriteLine($"Player {game.GetCurrentPlayer()} wins!");
                    gameOver = true;
                }
                else if (game.IsDraw())
                {
                    Console.Clear();
                    game.PrintBoard();
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                }
                else
                {
                    game.SwitchPlayer();
                }
            }
            else
            {
                Console.WriteLine("Column is full. Please choose another column.");
                Console.ReadLine();
            }
        }
    }
}
