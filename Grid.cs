using System.Text;

public class Grid
{
    private const char WidthChar = '-';
    private const char HeightChar = '|';
    private readonly int _height;
    private readonly int _width;
    private int _snakeLength = 10;
    private int _snakeStartX = 0;
    private int _snakeStartY = 0;
    private bool[,] _snakeGrid;

    public Grid(int height, int width)
    {
        _height = height;
        _width = width;
    }

    public string GetTheBigGridString()
    {
        var builder = new StringBuilder();

        return builder.ToString();
    }

    public static string[,] TestTheGrid(int height, int width)
    {
        var array = new string[height, width];

        for (int h = 0; h < height; h++)
        {
            for (var w = 0; w < width; w++)
            {
                array[h, w] = ((h * width) + w).ToString();
            }
        }

        return array;
    }
}