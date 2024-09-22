using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BuildFence : BuildBase
{
    [SerializeField] protected GameObject leftWall;
    [SerializeField] protected GameObject bottomWall;

    public override void Build()
    {
        base.Build();
        RenderWall.Instance.Renderer();

    }

    public void EnableBottomWall(bool enable)
    {
        bottomWall.SetActive(enable);
    }

    public void EnableLeftWall(bool enable)
    {
        leftWall.SetActive(enable);
    }

}
