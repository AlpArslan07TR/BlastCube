using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class DiscoDisco : Combo
{
    [Inject] private Board _board;

    public DiscoDisco(Cell tappedCell, List<Cell> comboCells) : base(tappedCell, comboCells)
    {
        TappedCell = tappedCell;
        comboCells = comboCells;
    }

    protected override List<Cell> GetExplodingCells()
    {
        return _board.Cells.Cast<Cell>().ToList();
    }
}
