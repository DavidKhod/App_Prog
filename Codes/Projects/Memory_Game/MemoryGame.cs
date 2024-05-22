using System;

public class MemoryGame
{
    private int[,] board;

    Random rnd = new Random();

    public MemoryGame(int size)
    {
        this.board = new int[size, size];
        StartBoard();
    }

    public MemoryGame()
    {
        this.board = new int[5, 5];
        StartBoard();
    }

    public int GetValueByIndex(int i, int j)
    {
        return board[i, j];
    }

    public void Shuffle()
    {
        for (int i = 0; i < board.GetLength(0); i++)
            for (int j = 0; j < board.GetLength(1); j++)
                Swap(i, j);
    }

    private void Swap(int i, int j)
    {
        var temp = board[i, j];
        int tempI = rnd.Next(board.GetLength(0));
        int tempJ = rnd.Next(board.GetLength(1));
        board[i, j] = board[tempI, tempJ];
        board[tempI, tempJ] = temp;
    }

    private void StartBoard()
    {
        int cnt = 0;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1) - 1; j += 2)
            {
                board[i, j] = cnt;
                board[i, j + 1] = cnt++;
            }
        }
        Shuffle();
    }

    public bool AreSame(int[] first, int[] second)
    {
        return board[first[0], first[1]] == board[second[0], second[1]];
    }

}