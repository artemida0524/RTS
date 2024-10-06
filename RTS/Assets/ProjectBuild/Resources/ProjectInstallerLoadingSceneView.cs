using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstallerLoadingSceneView : MonoInstaller
{
    [SerializeField] private LoadingSceneBase loadingSceneDefault;

    public override void InstallBindings()
    {
        Container
            .Bind<ILoadingScene>()
            .FromComponentInNewPrefab(loadingSceneDefault)
            .AsSingle()
            ;
    }
}
