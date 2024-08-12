using UnityEngine;
using Zenject;

public class FallAnimation : MonoBehaviour
{
    [Inject] ItemStatsSO _itemStatsSO;

    [HideInInspector] public Item item;
    [HideInInspector] public Cell TargetCell;
    public bool IsFalling {  get; private set; }
    private float _currentVel;
    private Vector3 _targetPos;

    private void Awake()
    {
        _currentVel = _itemStatsSO.startVel;
    }

    public void FallTo(Cell targetCell)
    {
        if (targetCell != null && targetCell.Y >= TargetCell.Y) return;
        {
            TargetCell = targetCell;
            item.cell = targetCell;
        }
    }
}
