using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;


public class MazeRunner : IMaze<IShell>
{
    public int Size => n;
    public IShell[,] Maze => maze;

    private Random random = new Random();
    private const int Wall = -1;
    private const int Path = 0;
    private const int Win = 1;
    private const int Start = 2;

    int n;
    IShell[,] maze;
    private int[,] _maze;
    public MazeRunner(int n)
    {
        if (n % 2 == 0) n++;
        this.n = n;
        _maze = new int[n, n];
        MakeStandarInitialMaze();
        MakeMaze();
    }
    private void MakeStandarInitialMaze(){
        maze = new IShell[Size,Size];
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i,j] = new Shell(-1);
            }
        }
    }
    private void MakeMaze()
    {
        int startX = 0, startY = 0;

        InitializeMaze();
        SetStartPt(ref startX, ref startY);
        for (int i = 0; i < Size * 20; i++)
        {
            GeneratePath(ref startX, ref startY);
        }
        AssignamentMaze();
    }
    private void AssignamentMaze()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                maze[i, j].wall = _maze[i, j];
            }
        }
    }

    private void InitializeMaze()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                _maze[i, j] = Wall;
            }
        }
    }

    private void SetStartPt(ref int current_row, ref int current_col)
    {
        current_col = (random.Next(Size / 2) * 2 + 1);
        current_row = (random.Next(Size / 2) * 2 + 1);

        _maze[current_row, current_col] = Path;
    }
    private void GeneratePath(ref int current_row, ref int current_col)
    {
        int iterations = 0;
        bool IsDone = false;
        while (!IsDone && iterations < Size / 2)
        {
            int direction = random.Next(4);
            switch (direction)
            {
                case 0:
                    if (current_row - 2 >= 0)
                    {
                        if (_maze[current_row - 2, current_col] != Path)
                        {
                            _maze[current_row - 1, current_col] = Path;
                            _maze[current_row - 2, current_col] = Path;
                            current_row -= 2;
                            IsDone = true;
                        }
                    }
                    break;

                case 1:
                    if (current_col - 2 >= 0)
                    {
                        if (_maze[current_row, current_col - 2] != Path)
                        {
                            _maze[current_row, current_col - 1] = Path;
                            _maze[current_row, current_col - 2] = Path;
                            current_col -= 2; IsDone = true;
                        }
                    }
                    break;
                case 2:
                    if (current_col + 2 < Size)
                    {
                        if (_maze[current_row, current_col + 2] != Path)
                        {
                            _maze[current_row, current_col + 1] = Path;
                            _maze[current_row, current_col + 2] = Path;
                            current_col += 2; IsDone = true;
                        }
                    }
                    break;
                case 3:
                    if (current_row + 2 < Size)
                    {
                        if (_maze[current_row + 2, current_col] != Path)
                        {
                            _maze[current_row + 1, current_col] = Path;
                            _maze[current_row + 2, current_col] = Path;
                            current_row += 2;
                            IsDone = true;
                        }
                    }
                    break;
            }
            iterations++;
        }
        if (!IsDone)
        {
            SetStartPt(ref current_row, ref current_col);
        }

    }
}