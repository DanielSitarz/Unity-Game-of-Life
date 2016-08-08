using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOfLife : MonoBehaviour
{
    [SerializeField]
    private int _boardWidth;
    [SerializeField]
    private int _boardHeight;

    [SerializeField]
    private RawImage _boardImage;

    [Range(0.05f, 1f), SerializeField]
    private float _alivePropability = 0.75f;

    [Range(1, 60), SerializeField]
    private int _ticksPerSecond = 1;

    [SerializeField]
    private int _minimumWidth = 10;
    [SerializeField]
    private int _maximumWidth = 256;
    [SerializeField]
    private int _minimumHeight = 10;
    [SerializeField]
    private int _maximumHeight = 256;

    private Board _board;
    private Ticker _ticker;

    private bool _isInitialized = false;

    public int TicksPerSecond
    {
        get
        {
            return _ticksPerSecond;
        }
        set
        {
            _ticksPerSecond = value;
            _ticker.TicksPerSecond = value;
        }
    }

    void Awake()
    {
        _board = new Board(_boardWidth, _boardHeight, _boardImage, _alivePropability);

        _ticker = new Ticker(_board);
        _ticker.TicksPerSecond = _ticksPerSecond;
    }

    void Start()
    {
        _board.Init();

        _isInitialized = true;
    }

    void LateUpdate()
    {
        if (_isInitialized)
        {
            _ticker.Update();
        }
    }

    public void NewGame()
    {
        _board.New();
        _ticker.Reset();
    }

    public void ResizeBoard(float factor)
    {
        int newWidth = Mathf.FloorToInt(factor * _maximumWidth);
        int newHeight = Mathf.FloorToInt(factor * _maximumHeight);

        if (newWidth < _minimumWidth) newWidth = _minimumWidth;
        if (newHeight < _minimumHeight) newHeight = _minimumHeight;

        _board.ResizeBoard(newWidth, newHeight);

        NewGame();
    }
}
