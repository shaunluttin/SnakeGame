using System.Text;

public struct Point
{
    public int Y; // height
    public int X; // width

    public Point(int y, int x)
    {
        Y = y;
        X = x;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Point))
        {
            return false;
        }

        var val = (Point)obj;
        return val.X == this.X && val.Y == this.Y;
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
    private int _currentSnakeLength = 5;
    private Direction _snakeIsMoving = Direction.Right;
    private int _snakeInsertionCounter = 0;

    public Grid(int height, int width)
    {
        _snakeGrid = new int[height, width];

        InsertSnakeBitIntoGrid(_currentSnakeStart);

        MoveSnake();
    }

    public void MoveSnake()
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

        // height
        for (int y = 0; y <= GetGridBoundaryY(); y++)
        {
            builder.AppendLine();

            // width
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

    public static string[,] TestTheGrid(int height, int width)
    {
        var array = new string[height, width];

        for (int h = 0; h < array.GetLength(0); h++)
        {
            for (var w = 0; w < array.GetLength(1); w++)
            {
                array[h, w] = ((h * width) + w).ToString();
            }
        }

        return array;
    }
}