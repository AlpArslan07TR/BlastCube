using System;
using UnityEngine;
using Zenject;

namespace Game.Items
{
    public class CubeItem : Item
    {
        [Inject] ImageLibService _imageLibService;
        private MatchType _matchType;

        public void Prepare(ItemBase itemBase,MatchType matchType,ItemType itemType)
        {
            ItemType = itemType;
            _matchType = matchType;
            Init(itemBase, GetSpriteForMatchType());
        }

        private Sprite GetSpriteForMatchType()
        {
            switch (_matchType)
            {
                case MatchType.None:
                    break;
                case MatchType.Green:
                    return _imageLibService.Images.GreenCube;
                case MatchType.Yellow:
                    return _imageLibService.Images.YellowCube;
                case MatchType.Blue:
                    return _imageLibService.Images.BlueCube;
                case MatchType.Red:
                    return _imageLibService.Images.redCube;
                case MatchType.Pink:
                    return _imageLibService.Images.PinkCube;
                case MatchType.Purple:
                    return _imageLibService.Images.PurpleCube;
                case MatchType.SpecialType:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}


