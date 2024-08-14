using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour,ITouchable
{
    [SerializeField] private TextMeshPro labelText;
    [Inject] private Board _board;

    [HideInInspector] public Cell FirstCellBelow;


    public bool IsFillingCell { get; private set; }
    public List<Cell> Neigbours { get; private set; } = new();
    public int X {  get; private set; }
    public int Y { get; private set; }
   


    public Item Item
    {
        get => _item;

        set
        {
            if(Item==value) return;

            var oldItem = _item;
            _item = value;

            if(oldItem !=null && Equals(oldItem.cell, this))
            {
                oldItem.cell = null;
            }
            if(value != null)
            {
                value.cell = this;
            }
        }
    }

    private Item _item;



    public void Prepare(int x,int y)
    {
        X = x;
        Y = y;

        IsFillingCell = Y == _board.Cols - 1;
        transform.localPosition = new Vector3(x, y);

        SetLabel();
        UpdateNeighbors();
    }

    public bool HasItem()
    {
        return Item!=null;
    }

    public bool IsFalling()
    {
        //todo:update here
        return false;
    }

    public Cell GetFallTarget()
    {
        var targetCell = this;
        while (targetCell.FirstCellBelow != null && !targetCell.FirstCellBelow.HasItem())
        {
            targetCell = targetCell.FirstCellBelow;
        }
        return targetCell;
    }

    private void UpdateNeighbors()
    {
        var up = _board.GetNeighborWithDirection(this,Directions.Up);
        var down = _board.GetNeighborWithDirection(this, Directions.Down);
        var left = _board.GetNeighborWithDirection(this, Directions.Left);
        var right = _board.GetNeighborWithDirection(this, Directions.Right);

        if (up != null) Neigbours.Add(up);
        if (down != null) Neigbours.Add(down);
        {
            Neigbours.Add(down);
            FirstCellBelow = down;
        }       
        if (left != null) Neigbours.Add(left);
        if (right != null) Neigbours.Add(right);

    }

    private void SetLabel()
    {
        var cellName = $"{X}:{Y}";
        labelText.text = cellName;
        gameObject.name = $"Cell{cellName}";
    }
    public class CellFactory : PlaceholderFactory<Cell> { }

}
