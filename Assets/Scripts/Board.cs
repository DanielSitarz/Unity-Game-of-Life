using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Board : MonoBehaviour
{
    public static Board instance;

    [SerializeField]
    private int _width = 10;
    [SerializeField]
    private int _height = 10;

    [SerializeField]
    private int _minimumWidth = 10;
    [SerializeField]
    private int _maximumWidth = 256;
    [SerializeField]
    private int _minimumHeight = 10;
    [SerializeField]
    private int _maximumHeight = 256;

    [Range(0.05f, 1f)]
    public float alivePropability = 0.75f;

    public RawImage board;

    private Texture2D _boardTexture;

    private List<Cell> _cells;

    private Generations _generations;    

    public int CellsAmount
    {
        get
        {
            return _cells.Count;
        }
    }

    void Awake()
    {
        instance = this;

        _cells = new List<Cell>();        

        CreateBoardTexture();
    }

    void Start()
    {
        _generations = Generations.instance;

        PopulateBoard();

        AddNeighboursForCells();        

        New();
    }

    public void New()
    {
        KillAllCells();

        SetAllCellsToRandomStates();

        _generations.Reset();
    }

    private void CreateBoardTexture()
    {
        _boardTexture = new Texture2D(_width, _height, TextureFormat.RGB24, false);
        _boardTexture.anisoLevel = 1;
        _boardTexture.filterMode = FilterMode.Point;
        board.texture = _boardTexture;
    }

    public void ResizeBoard(int newWidth, int newHeight)
    {
        _width = newWidth;
        _height = newHeight;        

        CreateBoardTexture();

        PopulateBoard();

        AddNeighboursForCells();

        New();
    }

    public void DrawCells()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {                
                _boardTexture.SetPixel(x, y, _cells[y + x * _height].Color);
            }
        }

        _boardTexture.Apply();
    }

    public void PopulateBoard()
    {
        _cells.Clear();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Cell cell = new Cell();

                _cells.Add(cell);
            }
        }
    }    

    public void SetAllCellsToRandomStates()
    {
        foreach (Cell cell in _cells)
        {
            SetRandomCellState(cell);
        }
    }

    public void SetRandomCellState(Cell cell)
    {
        cell.SetCellState(UnityEngine.Random.value < alivePropability ? CellState.Alive : CellState.Dead);
    }

    public void KillAllCells()
    {
        foreach (Cell cell in _cells)
        {
            cell.currentCellState = CellState.Dead;
        }
    }

    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
    }

    private void AddNeighboursForCells()
    {
        List<Cell> neighbours = new List<Cell>();

        ListHelper listHelper = new ListHelper(_width, _height);

        for (int col = 0; col < _width; col++)
        {
            for (int row = 0; row < _height; row++)
            {
                int pos = row + col * _height;
                Cell cell = _cells[pos];

                neighbours.Clear();

                if (listHelper.IsOnTopRow(pos) == false)
                {
                    neighbours.Add(_cells[pos - 1]); // top

                    if (listHelper.IsOnLeftEdge(pos) == false)
                        neighbours.Add(_cells[pos - _height - 1]); // top left

                    if (listHelper.IsOnRightEdge(pos) == false)
                        neighbours.Add(_cells[pos + _height - 1]); // top right
                }

                if (listHelper.IsOnBottomRow(pos) == false)
                {
                    neighbours.Add(_cells[pos + 1]); // bottom

                    if (listHelper.IsOnLeftEdge(pos) == false)
                        neighbours.Add(_cells[pos - _height + 1]); // bottom left

                    if (listHelper.IsOnRightEdge(pos) == false)
                        neighbours.Add(_cells[pos + _height + 1]); // bottom right                
                }

                if (listHelper.IsOnLeftEdge(pos) == false)
                    neighbours.Add(_cells[pos - _height]); // left

                if (listHelper.IsOnRightEdge(pos) == false)
                    neighbours.Add(_cells[pos + _height]); // right                                                                      

                cell.AddNeighbours(neighbours);
            }
        }
    }

    public void CellsApplyLifeRules()
    {
        foreach (Cell cell in _cells)
        {
            cell.ApplyLifeRules();
        }
    }

    public void CellsCountAliveNeighbours()
    {
        foreach (Cell cell in _cells)
        {
            cell.CountAliveNeighbours();
        }
    }

    public void SetCellsTo(List<CellState> states)
    {
        int i = 0;
        foreach (Cell cell in _cells)
        {
            cell.SetCellState(states[i]);
            i++;
        }
    }

    public void SetZoom(float zoom)
    {
        int newWidth = Mathf.FloorToInt(zoom * _maximumWidth);
        int newHeight = Mathf.FloorToInt(zoom * _maximumHeight);

        if (newWidth < _minimumWidth) newWidth = _minimumWidth;
        if (newHeight < _minimumHeight) newHeight = _minimumHeight;

        ResizeBoard(newWidth, newHeight);
    }
}
