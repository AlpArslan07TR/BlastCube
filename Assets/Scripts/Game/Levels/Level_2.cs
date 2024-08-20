using System.Collections.Generic;

namespace Game.Levels
{
    public class Level_2 : LevelData
    {
        private Dictionary<ItemType, int> _fillTypes;

        public override void Initialize()
        {
            DefaultItemTypes = new[]
            {
                ItemType.RedCube,
                ItemType.BlueCube
            };

            RowCount = 5;
            ColCount = 8;

            GridData = new ItemType[RowCount, ColCount];

            for (int x = 0; x < RowCount; x++)
            {
                for (int y = 0; y < ColCount; y++)
                {
                    if (GridData[x, y] != ItemType.None) continue;

                    GridData[x, y] = GetRandomItemType();
                }
            }
        }

        public override ItemType GetNextFillItemType()
        {
            _fillTypes = new Dictionary<ItemType, int>
            {
                {ItemType.RedCube, 9},
                {ItemType.BlueCube, 1}
            };

            return GetRandomTypeFromWeight(_fillTypes);
        }
    }
}