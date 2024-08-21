using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ComboService
{
    public static void DoComboExplosion(List<Cell> comboCells,Cell tappedCell,DiContainer diContainer)
    {
        var comboType = CalculateComboType(comboCells);

        switch (comboType)
        {
            case ComboType.None:
                Debug.LogWarning("Combo type not found");
                break;
            case ComboType.RocketRocket:
                var combo=new RocketRocketCombo(tappedCell, comboCells);
                diContainer.Inject(combo);
                combo.TryExecute();
                break;
            case ComboType.BombRocket:
                break;
            case ComboType.BombBomb:
                break;
            case ComboType.DiscoBomb:
                break;
            case ComboType.DiscoRocket:
                break;
            case ComboType.DiscoDisco:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static ComboType CalculateComboType(List<Cell> comboCells)
    {
        var bombAmount = 0;
        var rocketAmount=0;
        var discoAmount = 0;

        foreach (var cell in comboCells)
        {
            var type=cell.Item.GetSpecialType();
            if (cell.Item.GetSpecialType() == SpecialType.Disco)
            {
                discoAmount++;
            }
            else if (type == SpecialType.Bomb)
            {
                bombAmount++;
            }
            else if (type == SpecialType.Rocket)
            {
                rocketAmount++;
            }
        }
        
        if (discoAmount > 1)
        {
            return ComboType.DiscoDisco;
        }
        if (discoAmount == 1 && bombAmount >= 1)
        {
            return ComboType.DiscoBomb;
        }
        if (discoAmount == 1 && rocketAmount >= 1)
        {
            return ComboType.DiscoRocket;
        }
        if (bombAmount > 1)
        {
            return ComboType.BombBomb;
        }
        if (bombAmount == 1 && rocketAmount >= 1)
        {
            return ComboType.BombRocket;
        }
        if (bombAmount == 0 && rocketAmount > 1)
        {
            return ComboType.RocketRocket;
        }

        Debug.LogWarning("Combo type not found");
        return ComboType.None;


    }
}
