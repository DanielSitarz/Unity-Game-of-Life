using UnityEngine;

public class Ticker
{
    public bool isStopped = false;
    public int generation = 0;

    public int TicksPerSecond
    {
        set
        {
            _tickTime = 1 / value;
        }
    }

    private float _tickTime;
    private float _nextTickTime;

    private Board _board;

    public Ticker(Board board)
    {
        _board = board;

        _nextTickTime = Time.time + _tickTime;
    }

    public void Update()
    {
        if (Time.time > _nextTickTime && !isStopped)
        {
            Tick();
            _nextTickTime = Time.time + _tickTime;
        }
    }

    public void Tick()
    {
        _board.CellsCountAliveNeighbours();
        _board.CellsApplyLifeRules();
        _board.DrawCells();

        generation++;
    }

    public void Reset()
    {
        generation = 0;
    }
}
