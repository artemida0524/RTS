using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BeginSceneInstaller : MonoInstaller
{
    [SerializeField] private BeginSceneViewBase _beginSceneView;

    public override void InstallBindings()
    {
        Container
            .Bind<IBeginSceneView>()
            .FromComponentInNewPrefab(_beginSceneView)
            .AsSingle();
    }
}
