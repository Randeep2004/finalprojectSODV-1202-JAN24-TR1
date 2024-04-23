using System;

public class ConnectFour
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;
    private int[,] board;
    private int currentPlayer;



    public ConnectFour()
    {
        board = new int[ROWS, COLUMNS];
        currentPlayer = 1;
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
}