using UnityEngine;
using Zenject;

public class Board : MonoBehaviour
{
    [Inject] Cell.CellFactory _cellFactory;
}
