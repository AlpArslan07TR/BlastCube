using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combo 
{   
        protected Cell TappedCell;
        protected List<Cell> ComboCells;

        public Combo(Cell tappedCell, List<Cell> comboCells)
        {
            ComboCells = new List<Cell>();
            TappedCell = tappedCell;
            ComboCells = comboCells;
        }

        protected abstract List<Cell> GetExplodingCells();

        public void TryExecute()
        {
            foreach (var comboCell in ComboCells)
            {
                comboCell.Item.RemoveItem();
            }

            var explodingCells = GetExplodingCells();

            foreach (var explodingCell in explodingCells)
            {
                if (explodingCell.HasItem())
                {
                    explodingCell.Item.TryExecute();
                }
            }
        }
    }

