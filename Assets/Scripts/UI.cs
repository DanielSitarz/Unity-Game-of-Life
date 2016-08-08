using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameOfLife _gameOfLife;

    [SerializeField]
    private Slider _ticksPerSecond;

    [SerializeField]
    private Slider _boardSizeFactor;

    void Start()
    {
        _ticksPerSecond.value = _gameOfLife.TicksPerSecond;
    }

    public void NewGame()
    {
        _gameOfLife.NewGame();
    }

    public void ResizeBoard(float factor)
    {
        _gameOfLife.ResizeBoard(factor);
    }

    public void SetTicksPerSecond(float ticksPerSecond)
    {
        _gameOfLife.TicksPerSecond = (int) ticksPerSecond;
    }
}
