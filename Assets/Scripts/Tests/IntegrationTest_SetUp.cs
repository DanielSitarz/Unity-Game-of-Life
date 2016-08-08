using UnityEngine;
using UnityEngine.UI;

public class IntegrationTest_SetUp : MonoBehaviour
{
    [SerializeField]
    private RawImage _boardImage;

    private Board _board;

    public int CellsCount
    {
        get
        {
            return _board.CellsCount;
        }
    }
           
    void Start()
    {
        _board = new Board(10, 10, _boardImage, 1f);
        _board.Init();      
    }    
}
