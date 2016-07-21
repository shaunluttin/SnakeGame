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
    private Point _currentSnakeStart;
    private Point _currentSnakeEnd;
    private int _currentSnakeLength = 14;
    private Direction _snakeIsMoving;

    public Grid(int height, int width)
    {
        _snakeGrid = new bool[height, width];
        _currentSnakeStart = new Point(0, 0);

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

                InsertSnakeBitIntoGrid(new Point(y, x));
                counter++;
            }
        }
    }

    public void InsertSnakeBitIntoGrid(Point point)
    {
        _snakeGrid[point.Y, point.X] = true;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        // height
        for (int y = 0; y < _snakeGrid.GetLength(0); y++)
        {
            builder.AppendLine();

            // width
            for (var x = 0; x < _snakeGrid.GetLength(1); x++)
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