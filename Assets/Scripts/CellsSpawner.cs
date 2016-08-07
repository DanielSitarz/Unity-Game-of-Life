using UnityEngine;
using System.Collections;
using System;

public class CellsSpawner : MonoBehaviour
{
    public static CellsSpawner instance;    

    public Transform cellsParent;
    public GameObject cellPrefab;    

    void Awake()
    {
        instance = this;
    }    

    public void PopulateBoard(Vector2 size)
    {
        Board _board = Board.instance;

        Vector3 newPosition = cellPrefab.transform.position;
        Quaternion rotation = cellPrefab.transform.rotation;

        for (float x = 0; x < size.x; x += cellPrefab.transform.localScale.x)
        {
            for (float y = 0; y < size.y; y += cellPrefab.transform.localScale.z)
            {
                newPosition.x = x;
                newPosition.z = y;

                GameObject cellGameObject = Instantiate(this.cellPrefab, newPosition, rotation, cellsParent) as GameObject;

                Cell cell = cellGameObject.GetComponent<Cell>();
            
                _board.AddCell(cell);                
            }
        }
    }
}
