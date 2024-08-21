using System;
using UnityEngine;
using Zenject;

public class Item : MonoBehaviour
{
  public Cell cell
    {
        get => _cell;
        set
        {
            if (_cell == value) return;

            var oldCell = _cell;
            _cell = value;

            if (oldCell != null && Equals(oldCell.Item, this))
            {
                oldCell.Item = null;
            }

            if (value == null) return;

            value.Item = this;
            gameObject.name=_cell.gameObject.name +""+GetType().Name;
        }
    }
    protected ItemType ItemType;
    protected bool CanFall = true;

    private FallAnimation _fallAnimation;
    private const int BaseSortingOrder = 10;
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _comboParticle;
    private Cell _cell;
    public GameParticle HintParticle { get; private set; }
    private int _childSpiteOrder;

    public virtual MatchType GetMatchType()
    {
        return MatchType.None;
    }

    public virtual ItemType GetItemType()
    {
        return ItemType.None;
    }

    public virtual SpecialType GetSpecialType()
    {
        return SpecialType.None;
    }

    public void Fall()
    {
        if(!CanFall) return;

        _fallAnimation.FallTo(cell.GetFallTarget());
    }

    public void RemoveItem()
    {
        cell.Item = null;
        
        Destroy(gameObject);
    }

    public virtual void TryExecute()
    {
        RemoveItem();
    }

    public virtual void SetHint(int groupCount)
    {

    }
    public bool IsFalling()
    {
        return _fallAnimation.IsFalling;
    }
    public bool IsParticlePlaying()
    {
        return HintParticle?.Particle.isPlaying ?? false;
    }

    public virtual void TryExecuteByNearMatch(MatchType matchType) { }

    protected virtual void ChangeSprite(Sprite newSprite)
    {
        _spriteRenderer.sprite = newSprite;
    }

    protected void Prepare(ItemBase itemBase,Sprite sprite)
    {
        _spriteRenderer=AddSprite(sprite);
        _fallAnimation = itemBase.FallAnimation;
        _fallAnimation.Item = this;
        
    }

    public void SetDefaultItemSprite()
    {
        _spriteRenderer.sprite = GetDefaultItemSprite();
    }

    protected virtual Sprite GetDefaultItemSprite()
    {
        return null;
    }

    private SpriteRenderer AddSprite(Sprite sprite)
    {
        var spriteRenderer= new GameObject("Sprite_"+_childSpiteOrder).AddComponent<SpriteRenderer>();
        spriteRenderer.transform.SetParent(transform);
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingLayerID = SortingLayer.NameToID("Items");
        spriteRenderer.sortingOrder = BaseSortingOrder + _childSpiteOrder++;

        return spriteRenderer;
    }

}
