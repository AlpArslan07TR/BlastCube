

using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RocketItem : SpecialItem
{
    [Inject] private ImageLibService _imageLibService;
    [Inject] private Board _board;
    public void PrepareRocketItem(ItemBase itembase,ItemType itemType)
    {
        ItemType = itemType;
        var sprite=GetDefaultItemSprite();
        Prepare(itembase,sprite);
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return ItemType switch
        {
            ItemType.VerticalRocket => _imageLibService.Images.rocketVertical,
            ItemType.HorizontalRocket => _imageLibService.Images.rocketHorizontal,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public override void TryExecute()
    {
        var explodingCells=GetExplodingCells();
        base.TryExecute();

        for(var i = 0; i < explodingCells.Count; i++)
        {
            if (explodingCells[i].HasItem())
            {
                explodingCells[i].Item.TryExecute();
            }
        }
    }
    protected override List<Cell> GetExplodingCells()
    {
        var explodingCells= new List<Cell>();

        var x = this.cell.X;
        var y =this.cell.Y;

        if(ItemType== ItemType.HorizontalRocket)
        {
            for(int i = -_board.Rows; i < _board.Rows; i++)
            {
                if (!_board.IsInBoardX(x + i)) continue;

                var cell = _board.Cells[x + i, y];

                if (cell.HasItem())
                {
                    explodingCells.Add(cell);
                }
            }
        }else if(ItemType== ItemType.VerticalRocket)
        {
            for (int j = -_board.Rows; j < _board.Rows; j++)
            {
                if (!_board.IsInBoardY(y + j)) continue;

                var cell = _board.Cells[x , j+ y];

                if (cell.HasItem())
                {
                    explodingCells.Add(cell);
                }
            }
        }
        else
        {
            Debug.LogError("RocketItem:Wrong Item Type");
        }
        return explodingCells;
    }
    public override SpecialType GetSpecialType()
    {
        throw new System.NotImplementedException();
    }
}
