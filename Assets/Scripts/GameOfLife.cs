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

    [Range(0f, 1f), SerializeField]
    private float _generationsAdvanceSpeed = 0.75f;

    private Board _board;
    private Generations _generations;

    private bool _isInitialized = false;

    void Awake()
    {
        _board = new Board(_boardWidth, _boardHeight, _boardImage, _alivePropability);

        _generations = new Generations(_board);
        _generations.advanceEveryS = _generationsAdvanceSpeed;
    }

    void Start()
    {                
        _board.Init();

        _isInitialized = true;
    }

    void Update()
    {
        if (_isInitialized)
        {
            _generations.Update();
        }            
    }
}
