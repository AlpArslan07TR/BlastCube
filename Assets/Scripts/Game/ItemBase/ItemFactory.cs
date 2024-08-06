using System;
using UnityEngine;
using Zenject;

public class ItemFactory : MonoBehaviour
{
    [Inject] private Item.Factory _factory;
    [Inject] private ItemBase.Factory _itemBaseFactory;

    public Item Create(ItemType itemType, Transform parent, int layerCount = 2, ItemType itemTypeCliked = ItemType.None)
    {
        var itemBase = _itemBaseFactory.Create();
        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.GreenCube:
                break;
            case ItemType.YellowCube:
                break;
            case ItemType.BlueCube:
                break;
            case ItemType.RedCube:
                break;
            case ItemType.PinkCube:
                break;
            case ItemType.PurpleCube:
                break;
            case ItemType.Balloon:
                break;
            case ItemType.GreenBalloon:
                break;
            case ItemType.YellowBalloon:
                break;
            case ItemType.BlueBalloon:
                break;
            case ItemType.RedBalloon:
                break;
            case ItemType.PinkBalloon:
                break;
            case ItemType.PurpleBalloon:
                break;
            case ItemType.Crate:
                break;
            case ItemType.Bomb:
                break;
            case ItemType.VerticalRocket:
                break;
            case ItemType.HorizontalRocket:
                break;
            case ItemType.Disco:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        }

        return null; //todo: return item
    }
}