using NUnit.Framework;

public class ListHelper_Tests
{
    ListHelper listHelper;
    int width = 10;
    int height = 10;

    [SetUp]
    public void SetUp()
    {
        listHelper = new ListHelper(width, height);
    }

    [Test]
    public void IsOn_TopRow(
        [Values(0, 10, 20, 30)] int pos)
    {
        bool result = listHelper.IsOnTopRow(pos);

        Assert.True(result);
    }

    [Test]
    public void IsNotOn_TopRow(
        [Values(1, 9, 11, 13)] int pos)
    {
        bool result = listHelper.IsOnTopRow(pos);

        Assert.False(result);
    }

    [Test]
    public void IsOn_BottomRow(
        [Values(9, 19, 29)] int pos)
    {
        bool result = listHelper.IsOnBottomRow(pos);

        Assert.True(result);
    }

    [Test]
    public void IsNotOn_BottomRow(
        [Values(0, 10, 18)] int pos)
    {
        bool result = listHelper.IsOnBottomRow(pos);

        Assert.False(result);
    }

    [Test]
    public void IsOn_LeftEdge(
        [Range(0, 9)] int pos)
    {
        bool result = listHelper.IsOnLeftEdge(pos);

        Assert.True(result);
    }

    [Test]
    public void IsNotOn_LeftEdge(
        [Range(10, 19)] int pos)
    {
        bool result = listHelper.IsOnLeftEdge(pos);

        Assert.False(result);
    }

    [Test]
    public void IsNotOn_RightEdge(
    [Values(0, 9, 15, 89)] int pos)
    {
        bool result = listHelper.IsOnRightEdge(pos);

        Assert.False(result);
    }

    [Test]
    public void IsOn_RightEdge(
    [Range(90, 99)] int pos)
    {
        bool result = listHelper.IsOnRightEdge(pos);

        Assert.True(result);
    }
}
