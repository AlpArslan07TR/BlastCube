using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName="ParticleServiceInstaller",menuName="Installers/ParticleServiceInstaller")]
public class ParticleServiceInstaller : ScriptableObjectInstaller<ParticleServiceInstaller>
{
    public ParticleServiceSettings settings;

    public override void InstallBindings()
    {
        Container.Bind<ParticleServiceSettings>().FromInstance(settings);
        Container.BindInterfacesAndSelfTo<ParticleService>().FromNew().AsSingle();

        foreach(var particleData in settings.particles)
        {
            Container.BindMemoryPool<GameParticle, GameParticle.Pool>()
                .WithId(particleData.id)
                .WithInitialSize(particleData.initialSize)
                .WithMaxSize(particleData.maxSize)
                .FromComponentInNewPrefab(particleData.particle)
                .UnderTransformGroup("Particles");
        }
    }
}
