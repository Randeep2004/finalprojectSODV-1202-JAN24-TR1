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