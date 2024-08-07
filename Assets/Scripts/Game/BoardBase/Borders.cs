using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CinemachineTargetGroup targetGroup;

    private const float offset = .4f;

    public void Prepare(int row,int col,List<Cell>cells)
    {
        spriteRenderer.size=new Vector2(row+offset,col+offset);
        targetGroup.m_Targets=new CinemachineTargetGroup.Target[cells.Count];

        for(var i = 0; i < cells.Count; i++)
        {
            targetGroup.m_Targets[i].target = cells[i].transform;
            targetGroup.m_Targets[i].weight = 1;
        }
    }
}
