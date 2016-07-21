using System.Text;
using System.Linq;

public class Grid
{
    private const char WidthChar = '-';
    private const char HeightChar = '|';
    private readonly int _height;
    private readonly int _width;
    private int _snakeLength = 10;
    private int _snakeX = 0;
    private int _snakeY = 0;
    private string[,] _gridArray;

    public Grid(int height, int width)
    {
        _height = height;
        _width = width;
        _gridArray = BuildTheGrid(height, width);
    }

    public string GetTheBigGridString()
    {
        var builder = new StringBuilder();
        return builder.ToString();
    }

    public static string[,] BuildTheGrid(int height, int width)
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

    public void AddTheSnakeToTheGrid(StringBuilder builder)
    {

    }

    public void ReplaceCharactersBetween(StringBuilder builder, int start, int end, char replacement)
    {

    }
}