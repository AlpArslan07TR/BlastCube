using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GamePlayInstaller", menuName = "Installers/GamePlayInstaller")]
public class GamePlayInstaller : ScriptableObjectInstaller<GamePlayInstaller>
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private ItemBase itemPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<Cell,Cell.CellFactory>().FromComponentInNewPrefab(cellPrefab).AsSingle();
        Container.BindFactory<ItemBase, ItemBase.ItemBaseFactory>().FromComponentInNewPrefab(itemPrefab).AsSingle();
    }
}