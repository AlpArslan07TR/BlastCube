

using System;
using System.Collections.Generic;

public class MatchFinder
{
    private bool[,] _visitedCells;

    public MatchFinder(int rowCount, int columnCount)
    {
        _visitedCells=new bool[rowCount, columnCount];
    }

    public List<Cell>FindMatches(Cell cell,MatchType matchType)
    {
        var resultCells = new List<Cell>();
        ClearVisitedCells();
        FindMatchesRecursive(cell, resultCells, matchType);
        return resultCells;
    }

    private void FindMatchesRecursive(Cell cell, List<Cell> resultCells, MatchType matchType)
    {
        if(cell == null) return;

        var x=cell.X;
        var y=cell.Y;

        if (_visitedCells[x, y]) return;

        if(!IsVisited(cell,matchType)) return;

        _visitedCells[x, y] = true;
        resultCells.Add(cell);

        var neighbours = cell.Neigbours;
        if (neighbours.Count == 0) return;

        foreach( var neighbour in neighbours )
        {
            FindMatchesRecursive(neighbour, resultCells, matchType);
        }
    }

    private bool IsVisited(Cell cell, MatchType matchType)
    {
        return cell.HasItem()
            && cell.Item.GetMatchType() == matchType
            && cell.Item.GetMatchType() != MatchType.None;
    }

    private void ClearVisitedCells()
    {
        for(var i=0;i< _visitedCells.GetLength(0);i++)
        {
            for(var j=0;j< _visitedCells.GetLength(1); j++)
            {
                _visitedCells[i,j] = false;
            }
        }
    }
}
