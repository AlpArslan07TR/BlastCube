using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public enum LevelName
{
    Level1
}
public class Level : MonoBehaviour
{
    [Inject] private ItemFactory _itemFactory;
    [SerializeField] private LevelName levelName;
    [SerializeField] private Transform itemParent;
    private Board _board;
    private LevelData _currentLevelData;

    [Inject]

    public void Initialize(Board board)
    {
        _board = board;

        GetLevelData();
        PrepareBoard();
        PrepareLevel();
    }

    void GetLevelData()
    {
        _currentLevelData = LevelDataFactory.Create(levelName);
    }

    private void PrepareBoard()
    {
        _board.Prepare(_currentLevelData.RowCount, _currentLevelData.ColCount);
    }

    private void PrepareLevel()
    {
        for(int x=0;x<_currentLevelData.GridData.GetLength(0);x++)
        {
            for(int y = 0; y < _currentLevelData.GridData.GetLength(1); y++)
            {
                var cell= _board.Cells[x,y];
                var itemType = _currentLevelData.GridData[x,y];
                var item = _itemFactory.Create(itemType,itemParent);

                if (item == null) continue;

                cell.Item = item;
                item.transform.position = cell.transform.position;
            }
        }
    }

    
}
