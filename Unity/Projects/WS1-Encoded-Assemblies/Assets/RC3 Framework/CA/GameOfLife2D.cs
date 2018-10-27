
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
    public GameOfLife2D(int countX, int countY)
    {
        _currentState = new int[countY, countX];
        _nextState = new int[countY, countX];
    }

    ///
    public void Step()
    {
        int countY = _currentState.GetLength(0);
        int countX = _currentState.GetLength(1);

        // calculate next state
        for (int y = 0; y < countY; y++)
        {
            for (int x = 0; x < countX; x++)
                Step(x, y);
        }

        // swap state buffers
        Swap(_currentState, _nextState);
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
        int countY = current.GetLength(0);
        int countX = current.GetLength(1);
        int sum = 0;

        foreach ((int dy, int dx) in _offsets)
        {
            int x1 = Wrap(x0 + dx, countX);
            int y1 = Wrap(y0 + dy, countY);

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

    ///
    private static void Swap<T>(ref T t0, ref T t1)
    {
        var temp = t0;
        t0 = t1;
        t1 = temp;
    }
}