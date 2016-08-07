using UnityEngine;
using System.Collections;

public class Generations : MonoBehaviour
{
    public static Generations instance;

    public bool isStopped = true;
    public int generation = 0;

    public float advanceEveryS = 0.5f;   
    private float _nextAdvanceTime;

    private Board _board;    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _board = Board.instance;

        _nextAdvanceTime = Time.time + advanceEveryS;
    }

    void Update()
    {
        if(Time.time > _nextAdvanceTime && !isStopped)
        {
            AdvanceToNextGeneration();
            _nextAdvanceTime = Time.time + advanceEveryS;            
        }        
    }

    public void AdvanceToNextGeneration()
    {
        _board.CellsCountAliveNeighbours();
        _board.CellsApplyLifeRules();
        _board.DrawCells();

        generation++;
    }

    public void SetAdvanceSpeed(float advanceEveryS)
    {
        this.advanceEveryS = 1 - advanceEveryS;
    }

    public void Reset()
    {
        generation = 0;
    }
}
