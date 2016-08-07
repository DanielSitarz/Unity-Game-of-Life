using NUnit.Framework;

public class LifeRules_Tests
{

    //  Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    //  Any live cell with two or three live neighbours lives on to the next generation.
    //  Any live cell with more than three live neighbours dies, as if by over-population.
    //  Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

    // Any dead cell without exactly three live neighbours stays dead.

    [Test]
    public void LifeRules_AliveAndFewerThan2_Dies(
        [Range(0, 1)] int neighboursCount)
    {
        CellState currentCellState = CellState.Alive;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Dead);
    }

    [Test]
    public void LifeRules_AliveAnd2or3_Lives(
        [Values(2, 3)] int neighboursCount)
    {
        CellState currentCellState = CellState.Alive;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Alive);
    }

    [Test]
    public void LifeRules_AliveAndMoreThan3_Dies(
        [Range(4, 8)] int neighboursCount)
    {
        CellState currentCellState = CellState.Alive;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Dead);
    }

    [Test]
    public void LifeRules_DeadWithExactly3_Lives()
    {
        CellState currentCellState = CellState.Dead;
        int neighboursCount = 3;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Alive);
    }

    [Test]
    public void LifeRules_DeadWithLessThan3_StaysDead(
        [Range(0, 2)] int neighboursCount)
    {
        CellState currentCellState = CellState.Dead;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Dead);
    }

    [Test]
    public void LifeRules_DeadWitMoreThan3_StaysDead(
        [Range(4, 8)] int neighboursCount)
    {
        CellState currentCellState = CellState.Dead;

        currentCellState = LifeRules.DetermineCellState(currentCellState, neighboursCount);

        Assert.AreEqual(currentCellState, CellState.Dead);
    }
}
