using Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform cellParent;
    [Inject] private Cell.CellFactory _cellFactory;
    [Inject] private SignalBus _signalBus;
    [Inject] private Borders _borders;
    [Inject] private ItemFactory _itemFactory;
    public int Rows { get; private set; }
    public int Cols { get; private set; }
    public Cell[,] Cells { get; private set; }

    private MatchFinder _matchFinder;

    private void Awake()
    {
        _signalBus.Subscribe<OnElementTappedSignal>(CellTapped);
    }
    private void OnDestroy()
    {
        _signalBus.Unsubscribe<OnElementTappedSignal>(CellTapped);
    }

    public void Prepare(int row, int col)
    {
        Rows = row;
        Cols = col;
        Cells = new Cell[Rows, Cols];

        _matchFinder = new MatchFinder(Rows, Cols);

        CreateCells();
        PrepareCells();

        _borders.Prepare(Rows, Cols, Cells.Cast<Cell>().ToList());
    }
    public Cell GetNeighborWithDirection(Cell cell, Directions direction)
    {
        var x = cell.X;
        var y = cell.Y;

        switch (direction)
        {
            case Directions.None:
                break;
            case Directions.Up:
                y += 1;
                break;
            case Directions.UpRight:
                y += 1;
                x += 1;
                break;
            case Directions.Right:
                x += 1;
                break;
            case Directions.DownRight:
                y -= 1;
                x += 1;
                break;
            case Directions.Down:
                y -= 1;
                break;
            case Directions.DownLeft:
                y -= 1;
                x -= 1;
                break;
            case Directions.Left:
                x -= 1;
                break;
            case Directions.UpLeft:
                y += 1;
                x -= 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);


        }
        if (x < 0 || x >= Rows || y < 0 || y >= Cols)
        {
            return null;
        }

        return Cells[x, y];
    }

    public bool IsInBoardX(int x)
    {
        return x < Rows && x >= 0;
    }
    public bool IsInBoardY(int y)
    {
        return y < Cols && y >= 0;
    }

    private void CellTapped(OnElementTappedSignal signal)
    {
        var cell = signal.Touchable.gameObject.GetComponent<Cell>();

        if (!IsTapValid(cell)) return;

        if (cell.Item.GetMatchType() == MatchType.SpecialType)
        {
            //todo:special type logic
        }

        var matches= GetMatchingCells(cell);
        var clickedType=cell.Item.GetItemType();

        if (!IsAllItemsDoneFalling(matches))
        {
            return;
        }
        ExploseMatchingCells(cell);
        TryCombineMatchingCellsToSpecialItem(cell,matches,clickedType);
    }

    private void TryCombineMatchingCellsToSpecialItem(Cell cell, List<Cell> matches, ItemType clickedType)
    {
        if (!MatchHelpers.CanMatch(matches.Count)) return;

        if (MatchHelpers.IsRocketMatch(matches.Count))
        {
            var rnd = UnityEngine.Random.Range(0, 2);
            var item = _itemFactory.Create(rnd==0?ItemType.HorizontalRocket:ItemType.VerticalRocket);
            cell.Item = item;
            item.transform.position=cell.transform.position;
        }else if (MatchHelpers.IsBombMatch(matches.Count))
        {
            var item=_itemFactory.Create(ItemType.Bomb);
            cell.Item=item;
            item.transform.position = cell.transform.position;

        }else if (MatchHelpers.IsDiscoMatch(matches.Count))
        {
            var item= _itemFactory.Create(ItemType.Disco,itemTypeCliked:clickedType);
            cell.Item=item;
            item.transform.position= cell.transform.position;
        }
    }

    private void ExploseMatchingCells(Cell cell)
    {
        var cells=GetMatchingCells(cell);
        if (cells.Count < MatchHelpers.MinMatchCount)
        {
            if (cell.Item.GetMatchType()==MatchType.SpecialType)
            {
                cell.Item.TryExecute();
            }
            return;
        }

        var matchType=cell.Item.GetMatchType();
        var neighboursOfCellGroup = FindNeighboursOfCellGroup(cells);

        for(int i = 0;i<cells.Count;i++)
        {
            neighboursOfCellGroup.Remove(cells[i]);
            var item = cells[i].Item;
            item.TryExecute();
        }

        foreach(var neighbour in neighboursOfCellGroup)
        {
            if (neighbour != null && neighbour.HasItem())
            {
                //todo:try execute by near match
            }
        }
    }

    private HashSet<Cell> FindNeighboursOfCellGroup(List<Cell> cells)
    {
        var neighbours=new HashSet<Cell>();
        for(var x=0; x < cells.Count; x++)
        {
            for(var y=0; y < cells[x].Neigbours.Count; y++)
            {
                neighbours.Add(cells[x].Neigbours[y]);
            }
        }
        return neighbours;
    }

    private bool IsAllItemsDoneFalling(List<Cell> cells)
    {
        foreach(var cell in cells)
        {
            if (cell.HasItem() && cell.Item.IsFalling())
            {
                return false;
            }
        }
        return true;
    }

    private List<Cell> GetMatchingCells(Cell cell)
    {
        return _matchFinder.FindMatches(cell, cell.Item.GetMatchType());
    }

    private bool IsTapValid(Cell cell)
    {
        return cell != null && cell.HasItem() && !cell.Item.IsFalling();
    }
   
    private void CreateCells()
    {
        for(int x = 0; x < Rows; x++)
        {
            for(int y = 0; y < Cols; y++)
            {
                var cell = _cellFactory.Create();
                cell.transform.SetParent(cellParent);
                Cells[x,y] = cell;
            }
        }
    }

    private void PrepareCells()
    {
        for (int x = 0;x < Rows; x++)
        {
            for( int y = 0;y < Cols; y++)
            {
                Cells[x, y].Prepare(x, y);
            }
        }
    }

}
