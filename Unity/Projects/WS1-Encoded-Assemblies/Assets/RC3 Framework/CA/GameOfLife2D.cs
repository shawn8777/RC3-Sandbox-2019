
using System;
using System.Collections.Generic;


public class GameOfLife2D
{
    private int[,] _currentState;
    private int[,] _nextState;

    private (int, int)[] _offsets = {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        // (0, 0), // don't consider self
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1),
    };

    ///
    public int[,] CurrentState
    {
        get { return _currentState; }
    }

    ///
    public int CountX
    {
        get { return _currentState.GetLength(1); }
    }

    ///
    public int CountY
    {
        get { return _currentState.GetLength(0); }
    }

    ///
    public GameOfLife2D(int countX, int countY)
    {
        _currentState = new int[countY, countX];
        _nextState = new int[countY, countX];
    }

    ///
    public void Step()
    {
        int nx = CountX;
        int ny = CountY;

        for (int y = 0; y < ny; y++)
        {
            for (int x = 0; x < nx; x++)
                Step(x, y);
        }
    }

    ///
    private void Step(int y, int x)
    {
        int state = _currentState[y, x];
        int sum = GetNeighborSum(y, x);

        if (state == 0)
            _nextState[y, x] = (sum == 3) ? 1 : 0;
        else
            _nextState[y, x] = (sum < 2 || sum > 3) ? 0 : 1;
    }

    ///
    private int GetNeighborSum(int y0, int x0)
    {
        var current = _currentState;
        int nx = CountX;
        int ny = CountY;
        int sum = 0;

        foreach ((int dy, int dx) in _offsets)
        {
            int x1 = Wrap(x0 + dx, nx);
            int y1 = Wrap(y0 + dy, ny);

            if (current[y1, x1] > 0)
                sum++;
        }

        return sum;
    }

    ///
    private static int Wrap(int i, int n)
    {
        i %= n;
        return (i < 0) ? i + n : i;
    }
}