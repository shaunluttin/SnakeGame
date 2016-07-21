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

    public Grid(int height, int width)
    {
        _height = height;
        _width = width;
    }

    public string GetTheBigGridString()
    {
        var builder = new StringBuilder();
        BuildTheGrid(builder);
        AddTheSnakeToTheGrid(builder);
        return builder.ToString();
    }

    public void BuildTheGrid(StringBuilder builder)
    {
        builder.AppendLine(new string(WidthChar, _width));
        Enumerable.Range(0, _height - 2).ToList().ForEach(x =>
        {
            builder.AppendLine("|" + new string(' ', _width - 2) + HeightChar);
        });
        builder.AppendLine(new string(WidthChar, _width));
    }

    public void AddTheSnakeToTheGrid(StringBuilder builder)
    {
        var snakeStartIndex 
            = _snakeX + 1
            + ((_snakeY + 1) * _width);

        ReplaceCharactersBetween(builder, 0, 10, 'x');

        ReplaceCharactersBetween(builder, _width + 1, _width + 1 + 10, 'x');
        
    }

    public void ReplaceCharactersBetween(StringBuilder builder, int start, int end, char replacement)
    {
        builder.Remove(start, end - start);
        builder.Insert(start, new string(replacement, end - start));

    }
}