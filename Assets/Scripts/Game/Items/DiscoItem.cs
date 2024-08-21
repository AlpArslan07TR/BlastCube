using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class DiscoItem : SpecialItem
{
    [Inject] private ImageLibService _imageLibService;
    [Inject] private Board _board;
    private ItemType _matchType;

    public void PrepareDiscoItem(ItemBase itemBase, ItemType itemType, ItemType itemClickedType)
    {
        ItemType = itemType;
        var sprite = GetDefaultItemSprite();
        _matchType = itemClickedType;
        Prepare(itemBase, sprite);
    }

    public override SpecialType GetSpecialType()
    {
        return SpecialType.Disco;
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return _imageLibService.Images.disco;
    }

    public override void TryExecute()
    {
        var explosionCells = GetExplodingCells();

        base.TryExecute();

        for (var i = 0; i < explosionCells.Count; i++)
        {
            if (explosionCells[i].HasItem())
            {
                explosionCells[i].Item.TryExecute();
            }
        }
    }

    protected override List<Cell> GetExplodingCells()
    {
        var explodingCells = new List<Cell>();

        var x = this.cell.X;
        var y = this.cell.Y;

        

        var cell = (Cell[,])_board.Cells.Clone();
        cell.Shuffle();

        /*var cellList = cell.Cast<Cell>().ToList();
        var sameColorCells = cellList.Where(c => c.HasItem())
            .Select(c => c.Item.GetItemType() == _matchType);
        */

        for (int i = 0; i < _board.Rows; i++)
        {
            for (int j = 0; j < _board.Cols; j++)
            {
                if (IsValid(cell[i, j],_matchType))
                {
                    explodingCells.Add(cell[i, j]);
                }
            }
        }

        return explodingCells;
    }

    private static bool IsValid(Cell cell,ItemType itemType)
    {
        return cell.HasItem() && cell.Item.GetItemType() == itemType;
    }
}