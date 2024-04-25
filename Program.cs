//SODV 1202
//RANDEEP SINGH DEOL
//PRASHANT PANDEY
//FINAL PROJECT
//BOW VALLEY COLLEGE
//MAHBUB MURSHED
//CONNECT 4

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
                board[i, j] = '#'; // Initialize with '#' symbol
            }
        }
    }

    public void PrintBoard()
    {
        Console.WriteLine("  1 2 3 4 5 6 7");
        for (int i = 0; i < ROWS; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < COLUMNS; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("---------------");
    }

    public bool DropPiece(int column)
    {
        for (int i = ROWS - 1; i >= 0; i--)
        {
            if (board[i, column] == '#')
            {
                board[i, column] = currentPlayer;
                return true;
            }
        }
        return false; // Column is full
    }

    public bool CheckWin()
    {
        // Check horizontally
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS - 3; j++)
            {
                if (board[i, j] != '#' && board[i, j] == board[i, j + 1] &&
                    board[i, j] == board[i, j + 2] && board[i, j] == board[i, j + 3])
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
                if (board[i, j] != '#' && board[i, j] == board[i + 1, j] &&
                    board[i, j] == board[i + 2, j] && board[i, j] == board[i + 3, j])
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
                if (board[i, j] != '#' && board[i, j] == board[i + 1, j + 1] &&
                    board[i, j] == board[i + 2, j + 2] && board[i, j] == board[i + 3, j + 3])
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
                if (board[i, j] != '#' && board[i, j] == board[i + 1, j - 1] &&
                    board[i, j] == board[i + 2, j - 2] && board[i, j] == board[i + 3, j - 3])
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
                if (board[i, j] == '#')
                {
                    return false; // Board is not full
                }
            }
        }
        return true; // Board is full
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    public char GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public int GetColumnForAI()
    {
        // Basic AI: Choose a random column
        return random.Next(0, COLUMNS);
    }

    public void ResetGame()
    {
        InitializeBoard();
        currentPlayer = 'X';
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool singlePlayer;
        bool replay = true;

        while (replay)
        {
            do
            {
                Console.Write("Enter '1' for single player or '2' for two players: ");
                if (!int.TryParse(Console.ReadLine(), out int playerChoice) || (playerChoice != 1 && playerChoice != 2))
                {
                    Console.WriteLine("Invalid input! Please enter '1' or '2'.");
                    continue;
                }

                singlePlayer = playerChoice == 1;
                break;
            } while (true);

            ConnectFour game = new ConnectFour(singlePlayer);
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                game.PrintBoard();
                Console.WriteLine($"Player {game.GetCurrentPlayer()}'s turn.");

                int column;
                if (singlePlayer && game.GetCurrentPlayer() == 'O')
                {
                    column = game.GetColumnForAI();
                    Console.WriteLine($"Computer chose column {column + 1}");
                }
                else
                {
                    do
                    {
                        Console.Write("Enter column (1-7): ");
                    } while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 7);
                    column--; // Adjust for 0-based indexing
                }

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
                    Console.WriteLine("This Column is full. Please enter another column.");
                    Console.ReadLine();
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainChoice = Console.ReadLine().ToLower();
            replay = playAgainChoice == "yes";
        }
    }
}
