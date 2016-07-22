using System.Text;
using System;
public class MainClass
{
    private const int REFRESH_RATE_MS = 100;

    public static void Main(string[] args)
    {
        var grid = new Grid(height: 20, width: 20, initialSnakeLength: 100);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);

            grid.MoveSnake();
            Console.WriteLine(grid.Render());

            System.Threading.Thread.Sleep(REFRESH_RATE_MS);
        }
    }
}

public struct Point
{
    public int Y; // height
    public int X; // width

    public Point(int y, int x)
    {
        Y = y;
        X = x;
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Grid
{
    private const char WidthChar = '-';
    private const char HeightChar = '|';
    private const char SnakeChar = '*';
    private int[,] _snakeGrid; // y, x
    private Point _currentSnakeStart = new Point(0, 0);
    private Point _currentSnakeEnd = new Point(0, 0);
    private int _currentSnakeLength = 1;
    private Direction _snakeIsMoving = Direction.Right;
    private int _snakeInsertionCounter = 0;
    private int _lowest = 1;

    public Grid(int height, int width, int initialSnakeLength)
    {
        _currentSnakeLength = initialSnakeLength;

        _snakeGrid = new int[height, width];

        InsertSnakeBitIntoGrid(_currentSnakeStart);

        CreateSnake();
    }

    public void MoveSnake()
    {
        var point = GetNextSnakePoint();
        InsertSnakeBitIntoGrid(point);
        RemoveLowestSnakeBitFromGrid();
    }

    public void CreateSnake()
    {
        var counter = 0;

        // height
        for (int y = 0; y <= GetGridBoundaryY(); y++)
        {
            // width
            for (var x = 0; x <= GetGridBoundaryX(); x++)
            {
                if (counter >= _currentSnakeLength)
                {
                    break;
                }

                var point = GetNextSnakePoint();
                InsertSnakeBitIntoGrid(point);
                counter++;
            }
        }
    }

    public void RemoveLowestSnakeBitFromGrid()
    {
        for (int y = 0; y <= GetGridBoundaryY(); y++)
        {
            for (int x = 0; x <= GetGridBoundaryX(); x++)
            {
                if (_snakeGrid[y, x] == _lowest)
                {
                    _snakeGrid[y, x] = 0;
                    _lowest++;
                    return;
                }
            }
        }
    }

    public bool IsPositionAvailableRight()
    {
        var candidate = _currentSnakeEnd.X + 1;
        return candidate <= GetGridBoundaryX()
            && _snakeGrid[_currentSnakeEnd.Y, candidate] == 0;
    }

    public bool IsPositionAvailableLeft()
    {
        var candidate = _currentSnakeEnd.X - 1;
        return candidate >= 0
            && _snakeGrid[_currentSnakeEnd.Y, candidate] == 0;
    }

    public bool IsPositionAvailableUp()
    {
        var candidate = _currentSnakeEnd.Y - 1;
        return candidate >= 0
            && _snakeGrid[candidate, _currentSnakeEnd.X] == 0;
    }

    public bool IsPositionAvailableDown()
    {
        var candidate = _currentSnakeEnd.Y + 1;
        return candidate <= GetGridBoundaryY()
            && _snakeGrid[candidate, _currentSnakeEnd.X] == 0;
    }

    public Point GetNextSnakePoint()
    {
        var point = new Point();

        if (_snakeIsMoving == Direction.Right)
        {
            if (!IsPositionAvailableRight())
            {
                _snakeIsMoving = Direction.Down;
                return GetNextSnakePoint();
            }

            point.Y = _currentSnakeEnd.Y;
            point.X = _currentSnakeEnd.X + 1;
        }

        if (_snakeIsMoving == Direction.Left)
        {
            if (!IsPositionAvailableLeft())
            {
                _snakeIsMoving = Direction.Up;
                return GetNextSnakePoint();
            }

            point.Y = _currentSnakeEnd.Y;
            point.X = _currentSnakeEnd.X - 1;
        }

        if (_snakeIsMoving == Direction.Down)
        {
            if (!IsPositionAvailableDown())
            {
                _snakeIsMoving = Direction.Left;
                return GetNextSnakePoint();
            }

            point.Y = _currentSnakeEnd.Y + 1;
            point.X = _currentSnakeEnd.X;
        }

        if (_snakeIsMoving == Direction.Up)
        {
            if (!IsPositionAvailableUp())
            {
                _snakeIsMoving = Direction.Right;
                return GetNextSnakePoint();
            }

            point.Y = _currentSnakeEnd.Y - 1;
            point.X = _currentSnakeEnd.X;
        }

        _currentSnakeEnd = point;
        return point;
    }

    public int GetGridBoundaryX()
    {
        return _snakeGrid.GetLength(1) - 1;
    }

    public int GetGridBoundaryY()
    {
        return _snakeGrid.GetLength(0) - 1;
    }

    public void InsertSnakeBitIntoGrid(Point point)
    {
        _snakeInsertionCounter++;
        _snakeGrid[point.Y, point.X] = _snakeInsertionCounter;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        for (int y = 0; y <= GetGridBoundaryY(); y++)
        {
            builder.AppendLine();
            for (var x = 0; x <= GetGridBoundaryX(); x++)
            {
                var isSnake = _snakeGrid[y, x] > 0;
                if (isSnake)
                {
                    builder.Append(SnakeChar);
                }
                else
                {
                    builder.Append(' ');
                }
            }
        }

        return builder.ToString();
    }
}