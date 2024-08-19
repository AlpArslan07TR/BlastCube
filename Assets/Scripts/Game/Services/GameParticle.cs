
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;
using System.Linq;


[RequireComponent(typeof(ParticleSystem))]
public class GameParticle : MonoBehaviour
{
    [Inject] private ParticleService _particleService;
    public ParticleSystem Particle {  get; private set; }

    private string _id;
    private CancellationTokenSource _cts;

    private void Awake()
    {
        _cts = new CancellationTokenSource();
        Particle=gameObject.GetComponent<ParticleSystem>();
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }

    public void SetID(string id)
    {
        _id=id;
    }

    private async void WaitDespawn()
    {
        try
        {
            await UniTask.WaitWhile(IsPlaying,cancellationToken: _cts.Token);

            _particleService.DeSpawn(_id, this);
            
        }
        catch (OperationCanceledException) { }
    }

    private bool IsPlaying()
    {
        return Particle.IsAlive(true)
            ||GetComponentsInChildren<ParticleSystem>().Any(childParticle=>childParticle.IsAlive(true));
    }

    public class Pool : MemoryPool<GameParticle> 
    {
        protected override void OnSpawned(GameParticle item)
        {
            base.OnSpawned(item);
            item.WaitDespawn();
        }
    }
}
