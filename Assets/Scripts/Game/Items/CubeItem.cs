using System;
using UnityEngine;
using Zenject;

public class CubeItem : Item
{
    [Inject] ImageLibService _imageLibService;
    private MatchType _matchType;

    public void Prepare(ItemBase itemBase, MatchType matchType, ItemType itemType)
    {
        ItemType = itemType;
        _matchType = matchType;
        Prepare(itemBase, GetSpriteForMatchType());
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

    public override void SetHint(int groupCount)
    {
        if (!MatchHelpers.IsMinSpecialMatch(groupCount))
        {
            SetDefaultItemSprite();
        }
        else if (MatchHelpers.IsRocketMatch(groupCount))
        {
            switch (_matchType)
            {
                case MatchType.None:
                    break;
                case MatchType.Green:
                    ChangeSprite(_imageLibService.Images.GreenCubeRocket);
                    break;
                case MatchType.Yellow:
                    ChangeSprite(_imageLibService.Images.YellowCubeRocket);
                    break;
                case MatchType.Blue:
                    ChangeSprite(_imageLibService.Images.BlueCubeRocket);
                    break;
                case MatchType.Red:
                    ChangeSprite(_imageLibService.Images.redCubeRocket);
                    break;
                case MatchType.Pink:
                    ChangeSprite(_imageLibService.Images.PinkCubeRocket);
                    break;
                case MatchType.Purple:
                    ChangeSprite(_imageLibService.Images.PurpleCubeRocket);
                    break;
                case MatchType.SpecialType:
                    break;
                default:
                    break;
            }
        }
        else if (MatchHelpers.IsBombMatch(groupCount))
        {
            switch (_matchType)
            {
                case MatchType.None:
                    break;
                case MatchType.Green:
                    ChangeSprite(_imageLibService.Images.GreenCubeBomb);
                    break;
                case MatchType.Yellow:
                    ChangeSprite(_imageLibService.Images.YellowCubeBomb);
                    break;
                case MatchType.Blue:
                    ChangeSprite(_imageLibService.Images.BlueCubeBomb);
                    break;
                case MatchType.Red:
                    ChangeSprite(_imageLibService.Images.redCubeBomb);
                    break;
                case MatchType.Pink:
                    ChangeSprite(_imageLibService.Images.PinkCubeBomb);
                    break;
                case MatchType.Purple:
                    ChangeSprite(_imageLibService.Images.PurpleCubeBomb);
                    break;
                case MatchType.SpecialType:
                    break;
                default:
                    break;
            }
        }
        else if (MatchHelpers.IsDiscoMatch(groupCount))
        {
            switch (_matchType)
            {
                case MatchType.None:
                    break;
                case MatchType.Green:
                    ChangeSprite(_imageLibService.Images.GreenCubeDisco);
                    break;
                case MatchType.Yellow:
                    ChangeSprite(_imageLibService.Images.YellowCubeDisco);
                    break;
                case MatchType.Blue:
                    ChangeSprite(_imageLibService.Images.BlueCubeDisco);
                    break;
                case MatchType.Red:
                    ChangeSprite(_imageLibService.Images.redCubeDisco);
                    break;
                case MatchType.Pink:
                    ChangeSprite(_imageLibService.Images.PinkCubeDisco);
                    break;
                case MatchType.Purple:
                    ChangeSprite(_imageLibService.Images.PurpleCubeDisco);
                    break;
                case MatchType.SpecialType:
                    break;
                default:
                    break;
            }
        }
    }

    public override MatchType GetMatchType()
    {
        return _matchType;
    }

    public override ItemType GetItemType()
    {
        return ItemType;
    }

    public override void TryExecute()
    {
        base.TryExecute();
    }

    protected override Sprite GetDefaultItemSprite()
    {
        return GetSpriteForMatchType();
    }
}


    


