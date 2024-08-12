using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ParticleServiceSettings",menuName ="Settings/ParticleServiceSettings")]
public class ParticleServiceSettings : ScriptableObject
{
    public GameParticleData[] particles;
}
