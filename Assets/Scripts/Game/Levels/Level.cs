using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    private Board _board;

    [Inject]

    public void Initialize(Board board)
    {
        _board = board;
    }

    
}
