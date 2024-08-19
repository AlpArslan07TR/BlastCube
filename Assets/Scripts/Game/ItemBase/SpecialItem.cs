using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SpecialItem : Item
{
    [Inject] private ParticleService _particleService;
    private GameParticle _hintParticle;
    private const MatchType matchType = MatchType.SpecialType;

    public override void SetHint(int groupCount)
    {
        if (groupCount >= 2)
        {
            if (_hintParticle == null)
            {
                _hintParticle=_particleService.Spawn("ComboParticle",transform.position);
            }
        }
        else
        {
            if (_hintParticle != null)
            {
                _particleService.DeSpawn("ComboParticle",_hintParticle);
            }
        }
    }

    public override MatchType GetMatchType()
    {
        return matchType;
    }

    public abstract override SpecialType GetSpecialType();
    
    protected virtual List<Cell> GetExplodingCells()
    {
        return null;
    }
    
}
