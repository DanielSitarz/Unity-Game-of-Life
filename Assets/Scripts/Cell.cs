using System;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public CellState currentCellState;
    
    private int _aliveNeighboursCount;

    public Color Color {
        get
        {
            return DetermineColor();
        }
    }

    private List<Cell> _neighbours = new List<Cell>();

    public void ApplyLifeRules()
    {        
        CellState newCellState = LifeRules.DetermineCellState(currentCellState, _aliveNeighboursCount);
        SetCellState(newCellState);
    }

    public void SetCellState(CellState newCellState)
    {
        currentCellState = newCellState;
    }     

    public void AddNeighbours(List<Cell> neighbours)
    {
        _neighbours.AddRange(neighbours);
    }

    public void CountAliveNeighbours()
    {
        _aliveNeighboursCount = 0;

        foreach (Cell cell in _neighbours)
        {
            if (cell.currentCellState == CellState.Alive)
            {
                _aliveNeighboursCount++;
            }
        }        
    }

    private Color DetermineColor()
    {
        Color color = Color.white;

        if (currentCellState == CellState.Alive)             
        {
            float rgb = 1 - _aliveNeighboursCount * 0.1f - 0.2f;            
            color = new Color(rgb, rgb, rgb, 1.0f);
        }

        return color;
    }
}
