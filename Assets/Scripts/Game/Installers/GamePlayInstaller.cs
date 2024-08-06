using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GamePlayInstaller", menuName = "Installers/GamePlayInstaller")]
public class GamePlayInstaller : ScriptableObjectInstaller<GamePlayInstaller>
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private ItemBase itemPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.Bind<Board>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<Cell,Cell.CellFactory>().FromComponentInNewPrefab(cellPrefab).AsSingle();
        Container.BindFactory<ItemBase, ItemBase.Factory>().FromComponentInNewPrefab(itemPrefab).AsSingle();
        Container.BindFactory<Item, Item.Factory>().FromComponentInNewPrefab(itemPrefab).AsSingle();
        Container.DeclareSignal<OnElementTappedSignal>();
        Container.DeclareSignal<OnEmptyTappedSignal>();
    }
}