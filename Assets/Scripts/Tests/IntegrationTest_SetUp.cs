using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class IntegrationTest_SetUp : MonoBehaviour
{
    void Start()
    {
        Board board = Board.instance;
        board.ResizeBoard(4, 1);

        board.KillAllCells();

        board.SetCellsTo(SpawnFourCellsRow());        

        board.DrawCells();

        board.CellsApplyLifeRules();

        board.DrawCells();
    }

    private List<CellState> SpawnFourCellsRow()
    {
        return new List<CellState>()
        {
            CellState.Alive,
            CellState.Alive,
            CellState.Alive,
            CellState.Alive
        };
    }

    public bool AllCellsAreDead()
    {
        return true;
    }
}
