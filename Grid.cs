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
    private bool[,] _snakeGrid; // height, width
    private Point _currentSnakeStart = new Point(0, 0);
    private Point _currentSnakeEnd = new Point(0, 0);
    private int _currentSnakeLength = 14;
    private Direction _snakeIsMoving = Direction.Right;

    public Grid(int height, int width)
    {
        _snakeGrid = new bool[height, width];

        InsertSnakeBitIntoGrid(_currentSnakeStart);

        MoveSnake();
    }

    public void MoveSnake()
    {
        var counter = 0;

        // height
        for (int y = 0; y < _snakeGrid.GetLength(0); y++)
        {
            // width
            for (var x = 0; x < _snakeGrid.GetLength(1); x++)
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

    public Point GetNextSnakePoint()
    {
        var point = new Point();

        if (_snakeIsMoving == Direction.Right)
        {
            if (_currentSnakeEnd.X + 1 >= GetGridBoundaryX())
            {
                _snakeIsMoving = Direction.Down;
                return GetNextSnakePoint();
            }

            point.Y = _currentSnakeEnd.Y;
            point.X = _currentSnakeEnd.X + 1;
        }

        if (_snakeIsMoving == Direction.Down)
        {
            if (_currentSnakeEnd.Y + 1 >= GetGridBoundaryY())
            {
                return _currentSnakeEnd; // TODO handle this case.
            }

            point.Y = _currentSnakeEnd.Y + 1;
            point.X = _currentSnakeEnd.X;
        }

        _currentSnakeEnd = point;
        return point;
    }

    public int GetGridBoundaryX()
    {
        return _snakeGrid.GetLength(1);
    }

    public int GetGridBoundaryY()
    {
        return _snakeGrid.GetLength(0);
    }

    public void InsertSnakeBitIntoGrid(Point point)
    {
        _snakeGrid[point.Y, point.X] = true;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        // height
        for (int y = 0; y < GetGridBoundaryY(); y++)
        {
            builder.AppendLine();

            // width
            for (var x = 0; x < GetGridBoundaryX(); x++)
            {
                var isSnake = _snakeGrid[y, x];
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