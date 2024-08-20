using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BombItem : SpecialItem
{
    [Inject] private ImageLibService _imageLibService;
    [Inject] private Board _board;
    private int _explosionRange = 1;
    public void PrepareBombItem(ItemBase itemBase,ItemType itemType)
    {
        ItemType=itemType;
        var sprite=GetDefaultItemSprite();
        Prepare(itemBase,sprite);
    }

    public override SpecialType GetSpecialType()
    {
        return SpecialType.Bomb;
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return _imageLibService.Images.bomb;
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
        var y=this.cell.Y;

        for (int i = -_explosionRange; i <= _explosionRange; i++)
        {
            for(int j = -_explosionRange; j <= _explosionRange; j++)
            {
                if (!_board.IsInBoard(x + i, y + j)) continue;

                var cell = _board.Cells[x+i, y + j];
                if (cell.HasItem())
                {
                    explodingCells.Add(cell);
                }
            }
            
        }
        return explodingCells;
    }
}
