using System.Text;

public class Grid
{
    private const char WidthChar = '-';
    private const char HeightChar = '|';
    private const char SnakeChar = '*';
    private bool[,] _snakeGrid; // height, width
    private int _currentSnakeStartY = 0; // height
    private int _currentSnakeStartX = 0; // width
    private int _currentSnakeLength = 1;
    private bool _snakeIsMovingHorizontally = true;

    public Grid(int height, int width)
    {
        _snakeGrid = new bool[height, width];
        _snakeGrid[_currentSnakeStartY, _currentSnakeStartX] = true;
    }

    public void MoveSnake()
    {
        if (_snakeIsMovingHorizontally)
        {
            if (!IsHittingWall())
            {
                MoveSnakeHorizontally();
            }
        }
    }

    private void MoveSnakeHorizontally()
    {
        var nextSnakeStartX = _currentSnakeStartX + 1;
        var nextSnakeEndX = nextSnakeStartX + _currentSnakeLength - 1;

        _snakeGrid[_currentSnakeStartY, _currentSnakeStartX] = false;
        _snakeGrid[_currentSnakeStartY, nextSnakeEndX] = true;

        _currentSnakeStartX = nextSnakeStartX;
    }

    private bool IsHittingWall()
    {
        return _currentSnakeStartX + _currentSnakeLength > _snakeGrid.GetLength(0);
    }

    public string Render()
    {
        var builder = new StringBuilder();

        for (int h = 0; h < _snakeGrid.GetLength(0); h++)
        {
            builder.AppendLine();
            for (var w = 0; w < _snakeGrid.GetLength(1); w++)
            {
                var isSnake = _snakeGrid[h, w];
                if (isSnake)
                {
                    builder.Append(SnakeChar);
                }
                else
                {
                    builder.Append(' ');
                }
                // System.Console.WriteLine($"{h} {w} {isSnake}");
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