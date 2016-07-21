using System.Text;
using System.Linq;

public class Grid
{
    private int _height;

    private int _width;

    public Grid(int height, int width)
    {
        _height = height;
        _width = width;
    }

    public string GetTheBigGridString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(new string('-', _width));
        Enumerable.Range(0, _height - 2).ToList().ForEach(x =>
        {
            builder.AppendLine("|" + new string(' ', _width - 2) + "|");
        });
        builder.AppendLine(new string('-', _width));
        return builder.ToString();
    }
}