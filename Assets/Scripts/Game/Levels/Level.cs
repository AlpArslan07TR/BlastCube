using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public enum LevelName
{
    Level1,
    Level2,
    Level_CrateTest
}
public class Level : MonoBehaviour
{
    [Inject] private ItemFactory _itemFactory;
    [Inject] private FallAndFillManager _fallAndFillManager;
    [SerializeField] private LevelName levelName;
    
    private Board _board;
    private LevelData _currentLevelData;
    private void Start()
    {
        GetLevelData();
        PrepareBoard();
        PrepareLevel();
        StartFalls();
    }
    [Inject]
    public void Initialize(Board board)
    {
        _board = board;

       
    }

    void GetLevelData()
    {
        _currentLevelData = LevelDataFactory.Create(levelName);
    }

    private void PrepareBoard()
    {
        Assert.IsNotNull(_board);
        Assert.IsNotNull(_currentLevelData);
        _board.Prepare(_currentLevelData.RowCount, _currentLevelData.ColCount);
    }

    private void PrepareLevel()
    {
        Assert.IsNotNull(_itemFactory);
        for(int x=0;x<_currentLevelData.GridData.GetLength(0);x++)
        {
            for(int y = 0; y < _currentLevelData.GridData.GetLength(1); y++)
            {
                var cell= _board.Cells[x,y];
                var itemType = _currentLevelData.GridData[x,y];
                var item = _itemFactory.Create(itemType);

                if (item == null) continue;

                cell.Item = item;
                item.transform.position = cell.transform.position;
            }
        }
    }

    private void StartFalls()
    {
        _fallAndFillManager.Prepare(_currentLevelData);
        _fallAndFillManager.StartFall();
    }

    
}
