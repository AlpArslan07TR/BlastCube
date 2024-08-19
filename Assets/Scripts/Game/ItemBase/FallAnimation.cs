using ModestTree;
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
        Assert.IsNotNull(targetCell);
        if (TargetCell != null && targetCell.Y >= TargetCell.Y)
        {
            return;
        }
        TargetCell = targetCell;
        item.cell = targetCell;
        _targetPos = TargetCell.transform.position;
        IsFalling = true;
    }

    private void Update()
    {
        if (!IsFalling) return;

        _currentVel += _itemStatsSO.acc;
        _currentVel = _currentVel >= _itemStatsSO.maxSpeed ? _itemStatsSO.maxSpeed : _currentVel;

        var p = item.transform.position;
        p.y = _currentVel * Time.deltaTime;

        if(p.y<=_targetPos.y)
        {
            IsFalling = false;
            TargetCell = null;
            p.y = _targetPos.y;
            _currentVel = _itemStatsSO.startVel;
        }

        item.transform.position = p;
    }
}
