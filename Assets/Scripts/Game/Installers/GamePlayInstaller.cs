using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GamePlayInstaller", menuName = "Installers/GamePlayInstaller")]
public class GamePlayInstaller : ScriptableObjectInstaller<GamePlayInstaller>
{
    public override void InstallBindings()
    {
    }
}