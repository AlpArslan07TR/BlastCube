using TMPro;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour,ITouchable
{
    [SerializeField] private TextMeshPro labelText;
    [Inject] private Board _board;
    public int X {  get; private set; }
    public int Y { get; private set; }
    public ListPool<Cell> Neighbors { get; private set; } = new();


    public Item Item
    {
        get => _item;

        set
        {
            if(Item==value) return;

            var oldItem = _item;
            _item = value;

            if(oldItem !=null && Equals(oldItem.cell, this))
            {
                oldItem.cell = null;
            }
            if(value != null)
            {
                value.cell = this;
            }
        }
    }

    private Item _item;



    public void Prepare(int x,int y)
    {
        X = x;
        Y = y;

        transform.localPosition = new Vector3(x, y);
        SetLabel();
    }

    private void SetLabel()
    {
        var cellName = $"{X}:{Y}";
        labelText.text = cellName;
        gameObject.name = $"Cell{cellName}";
    }
    public class CellFactory : PlaceholderFactory<Cell> { }

}
