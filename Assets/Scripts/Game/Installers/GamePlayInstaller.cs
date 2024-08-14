using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Installers/GameplayInstaller")]
public class GameplayInstaller : ScriptableObjectInstaller<GameplayInstaller>
{
    [Header("Prefabs")]
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private ItemBase itemBasePrefab;
    [Space]
    [SerializeField] private ItemStatsSO ItemStatsSO;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.Bind<Board>().FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<ImageLibService>().FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<Borders>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ItemFactory>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<Cell, Cell.CellFactory>()
            .FromComponentInNewPrefab(cellPrefab)
            .AsSingle();

        Container.BindFactory<ItemBase, ItemBase.Factory>().FromComponentInNewPrefab(itemBasePrefab).UnderTransformGroup("--Game/Level/ItemParent").AsSingle();
        Container.Bind<ItemStatsSO>().FromInstance(ItemStatsSO).AsSingle();
        Container.Bind<FallAndFillManager>().FromComponentsInHierarchy().AsSingle();

        Container.DeclareSignal<OnElementTappedSignal>();
        Container.DeclareSignal<OnEmptyTappedSignal>();
    }
}