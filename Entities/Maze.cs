using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Spectre.Console;
using Architecture.IShells;
using Architecture.IMazes;
using Variable.Globals;


public class MazeRunner : IMaze<IShell>
{
    public int Size => n;
    public IShell[,] Maze => maze;

    private Random random = new Random();
    

    int n;
    IShell[,] maze;
    int nplayer;
    private int[,] _maze;
    public MazeRunner(int Size, int numberPlayer)
    {
        if (Size % 2 == 0) Size++;
        n = Size;
        _maze = new int[n, n];
        nplayer = numberPlayer;
        MakeStandarInitialMaze();
        MakeMaze();
    }
    private void MakeStandarInitialMaze()
    {
        maze = new IShell[Size, Size];
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = new Shell(Global.Wall, i, j);
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
        Mask();
        SetWinCondicionAndStartPoint(nplayer);
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
                _maze[i, j] = Global.Wall;
            }
        }
    }

    private void SetStartPt(ref int current_row, ref int current_col)
    {
        current_col = (random.Next(Size / 2) * 2 + 1);
        current_row = (random.Next(Size / 2) * 2 + 1);

        _maze[current_row, current_col] = Global.Path;
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
                        if (_maze[current_row - 2, current_col] != Global.Path)
                        {
                            _maze[current_row - 1, current_col] = Global.Path;
                            _maze[current_row - 2, current_col] = Global.Path;
                            current_row -= 2;
                            IsDone = true;
                        }
                    }
                    break;

                case 1:
                    if (current_col - 2 >= 0)
                    {
                        if (_maze[current_row, current_col - 2] != Global.Path)
                        {
                            _maze[current_row, current_col - 1] = Global.Path;
                            _maze[current_row, current_col - 2] = Global.Path;
                            current_col -= 2; IsDone = true;
                        }
                    }
                    break;
                case 2:
                    if (current_col + 2 < Size)
                    {
                        if (_maze[current_row, current_col + 2] != Global.Path)
                        {
                            _maze[current_row, current_col + 1] = Global.Path;
                            _maze[current_row, current_col + 2] = Global.Path;
                            current_col += 2; IsDone = true;
                        }
                    }
                    break;
                case 3:
                    if (current_row + 2 < Size)
                    {
                        if (_maze[current_row + 2, current_col] != Global.Path)
                        {
                            _maze[current_row + 1, current_col] = Global.Path;
                            _maze[current_row + 2, current_col] = Global.Path;
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
    private void Mask()
    {
        bool existMask = false;
        do
        {
            existMask = false;
            for (int i = 1; i < Size - 1; i++)
            {
                for (int j = 1; j < Size - 1; j++)
                {
                    switch (_maze[i, j])
                    {
                        case Global.Wall:
                            if (_maze[i, j - 1] == Global.Wall && _maze[i, j + 1] == Global.Wall && _maze[i - 1, j - 1] == Global.Wall && _maze[i - 1, j] == Global.Path && _maze[i - 1, j + 1] == Global.Wall)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (_maze[i, j - 1] == Global.Wall && _maze[i, j + 1] == Global.Wall && _maze[i + 1, j - 1] == Global.Wall && _maze[i + 1, j] == Global.Path && _maze[i + 1, j + 1] == Global.Wall)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (_maze[i - 1, j] == Global.Wall && _maze[i + 1, j] == Global.Wall && _maze[i - 1, j + 1] == Global.Wall && _maze[i, j + 1] == Global.Path && _maze[i + 1, j + 1] == Global.Wall)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (_maze[i - 1, j] == Global.Wall && _maze[i + 1, j] == Global.Wall && _maze[i - 1, j - 1] == Global.Wall && _maze[i, j - 1] == Global.Path && _maze[i + 1, j - 1] == Global.Wall)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (j - 1 == 0 && _maze[i, j - 1] == Global.Wall && _maze[i + 1, j - 1] == Global.Wall && _maze[i, j + 1] == Global.Wall && _maze[i, j + 2] == Global.Wall && _maze[i, j + 3] == Global.Wall && _maze[i + 1, j] == Global.Path && _maze[i + 1, j + 1] == Global.Path && _maze[i + 1, j + 2] == Global.Path && _maze[i + 1, j + 3] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (j + 1 == Size - 1 && _maze[i, j + 1] == Global.Wall && _maze[i + 1, j + 1] == Global.Wall && _maze[i, j - 1] == Global.Wall && _maze[i, j - 2] == Global.Wall && _maze[i, j - 3] == Global.Wall && _maze[i + 1, j] == Global.Path && _maze[i + 1, j - 1] == Global.Path && _maze[i + 1, j - 2] == Global.Path && _maze[i + 1, j - 3] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (j + 1 == Size - 1 && _maze[i, j + 1] == Global.Wall && _maze[i - 1, j + 1] == Global.Wall && _maze[i, j - 1] == Global.Wall && _maze[i, j - 2] == Global.Wall && _maze[i, j - 3] == Global.Wall && _maze[i - 1, j] == Global.Path && _maze[i - 1, j - 1] == Global.Path && _maze[i - 1, j - 2] == Global.Path && _maze[i - 1, j - 3] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (j - 1 == 0 && _maze[i, j - 1] == Global.Wall && _maze[i - 1, j - 1] == Global.Wall && _maze[i, j + 1] == Global.Wall && _maze[i, j + 2] == Global.Wall && _maze[i, j + 3] == Global.Wall && _maze[i - 1, j] == Global.Path && _maze[i - 1, j + 1] == Global.Path && _maze[i - 1, j + 2] == Global.Path && _maze[i - 1, j + 3] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (i - 1 == 0 && _maze[i - 1, j] == Global.Wall && _maze[i - 1, j + 1] == Global.Wall && _maze[i + 1, j] == Global.Wall && _maze[i + 2, j] == Global.Wall && _maze[i + 3, j] == Global.Wall && _maze[i, j + 1] == Global.Path && _maze[i + 1, j + 1] == Global.Path && _maze[i + 2, j + 1] == Global.Path && _maze[i + 3, j + 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (i - 1 == 0 && _maze[i - 1, j] == Global.Wall && _maze[i - 1, j - 1] == Global.Wall && _maze[i + 1, j] == Global.Wall && _maze[i + 2, j] == Global.Wall && _maze[i + 3, j] == Global.Wall && _maze[i, j - 1] == Global.Path && _maze[i + 1, j - 1] == Global.Path && _maze[i + 2, j - 2] == Global.Path && _maze[i + 3, j - 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (i + 1 == Size - 1 && _maze[i + 1, j] == Global.Wall && _maze[i + 1, j + 1] == Global.Wall && _maze[i - 1, j] == Global.Wall && _maze[i - 2, j] == Global.Wall && _maze[i - 3, j] == Global.Wall && _maze[i, j + 1] == Global.Path && _maze[i - 1, j + 1] == Global.Path && _maze[i - 2, j + 2] == Global.Path && _maze[i - 3, j + 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            if (i + 1 == Size - 1 && _maze[i + 1, j] == Global.Wall && _maze[i + 1, j - 1] == Global.Wall && _maze[i - 1, j] == Global.Wall && _maze[i - 2, j] == Global.Wall && _maze[i - 3, j] == Global.Wall && _maze[i, j - 1] == Global.Path && _maze[i - 1, j - 1] == Global.Path && _maze[i - 2, j - 2] == Global.Path && _maze[i - 3, j - 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Path;
                                existMask = true;
                            }
                            break;
                        case Global.Path:
                            if (_maze[i - 1, j] == Global.Path && _maze[i - 1, j - 1] == Global.Path && _maze[i - 1, j + 1] == Global.Path && _maze[i, j - 1] == Global.Wall && _maze[i, j + 1] == Global.Wall && _maze[i + 1, j - 1] == Global.Path && _maze[i + 1, j] == Global.Path && _maze[i + 1, j + 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Wall;
                                existMask = true;
                            }
                            if (_maze[i - 1, j] == Global.Wall && _maze[i - 1, j - 1] == Global.Path && _maze[i - 1, j + 1] == Global.Path && _maze[i, j - 1] == Global.Path && _maze[i, j + 1] == Global.Path && _maze[i + 1, j - 1] == Global.Path && _maze[i + 1, j] == Global.Wall && _maze[i + 1, j + 1] == Global.Path)
                            {
                                _maze[i, j] = Global.Wall;
                                existMask = true;
                            }
                            break;
                    }
                }
            }
        } while (existMask);
    }
    private void SetWinCondicionAndStartPoint(int n = 1)
    {
        for (int i = 0; i < n; i++)
        {
            SetInit();
            if (i == 0)
                continue;
            SetWin();
        }
        for (int i = 0; i < 2 * Size; i++)
        {
            int x = random.Next(Size / 4, 3 * Size / 4);
            int y = random.Next(Size / 4, 3 * Size / 4);
            if (_maze[x, y] == Global.Wall && (_maze[x - 1, y] == Global.Path || _maze[x + 1, y] == Global.Path || _maze[x, y - 1] == Global.Path || _maze[x, y + 1] == Global.Path))
            {
                _maze[x, y] = Global.TeleportZone;
                break;
            }
        }

    }
    private void SetWin()
    {
        int i = 0;
        while (i < Size)
        {
            int x = random.Next(Size - 1);
            if (_maze[x,Size - 2] == Global.Path && _maze[x,Size - 1] == Global.Wall && _maze[x,1] == Global.Path && _maze[x,0] == Global.Wall)
            {
                _maze[x,Size - 1] = Global.Win;
                _maze[x,0] = Global.Win;
                return;
            }
            i++;
        }
        throw new Exception("No se pudo setear la casilla de victoria");
    }
    private void SetInit()
    {
        int i = 0;
        while (i < 2*Size)
        {
            int x = random.Next(Size - 1);
            if (_maze[1, x] == Global.Path && _maze[0, x] == Global.Wall && _maze[Size -1,x] == Global.Wall && _maze[Size-2,x] == Global.Path )
            {
                _maze[0, x] = Global.Start;
                _maze[Size - 1,x] = Global.Start;
                return;
            }
            i++;
        }
        throw new Exception("No se pudo setear una casilla de salida");
    }
}