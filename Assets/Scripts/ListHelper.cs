public class ListHelper
{
    public ListHelper(int width, int height)
    {
        _width = width;
        _height = height;
    }

    private int _width;
    private int _height;

    public bool IsOnRightEdge(int pos)
    {
        return pos >= _height * _width - _height;
    }

    public bool IsOnLeftEdge(int pos)
    {
        return pos < _height;
    }

    public bool IsOnBottomRow(int pos)
    {
        return pos % _height == _height - 1;
    }

    public bool IsOnTopRow(int pos)
    {
        return pos % _height == 0;
    }
}
