public enum CellState
{
    Dead,
    Alive,    
}

//  Any live cell with fewer than two live neighbours dies, as if caused by under-population.
//  Any live cell with two or three live neighbours lives on to the next generation.
//  Any live cell with more than three live neighbours dies, as if by over-population.
//  Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

// Any dead cell without exactly three live neighbours stays dead.

public static class LifeRules
{
    public static CellState DetermineCellState(CellState currentCellState, int neighboursCount)
    {
        CellState newCellState = CellState.Alive;

        switch (currentCellState)
        {
            case CellState.Alive:
                if (neighboursCount < 2 || neighboursCount > 3)
                {
                    newCellState = CellState.Dead;
                }                
                break;
            case CellState.Dead:
                if (neighboursCount == 3)
                {
                    newCellState = CellState.Alive;
                }
                else
                {
                    newCellState = CellState.Dead;
                }
                break;
        }        

        return newCellState;
    }
}
