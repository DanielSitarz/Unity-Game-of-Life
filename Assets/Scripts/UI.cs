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

    [SerializeField]
    private Text _generationsStatistics;

    void Start()
    {
        _ticksPerSecond.value = _gameOfLife.TicksPerSecond;
    }

    void LateUpdate()
    {
        UpdateGenerationsStatistics();
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
        if (ticksPerSecond == _ticksPerSecond.maxValue)
        {
            ticksPerSecond = -1;
        }

        _gameOfLife.TicksPerSecond = (int)ticksPerSecond;
    }

    public void UpdateGenerationsStatistics()
    {
        int currentGeneration = _gameOfLife.GetCurrentGeneration();

        float generationsPerSecond = _gameOfLife.GetTicksPerSecond();

        _generationsStatistics.text = string.Format("{0} ({1})", currentGeneration, generationsPerSecond);
    }
}
