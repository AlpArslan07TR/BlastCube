using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform cellParent;
    [Inject] private Cell.CellFactory _cellFactory;
    [Inject] private SignalBus _signalBus;
    [Inject] private Borders _borders;
    public int Rows { get; private set; }
    public int Cols { get; private set; }
    public Cell[,] Cells { get; private set; }

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

    private void CellTapped(OnElementTappedSignal signal)
    {
        var cell = signal.Touchable.gameObject.GetComponent<Cell>();
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
