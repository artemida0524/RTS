using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstallerLoadSaveData : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IPlayerPrefsService>()
            .To<ServicePlayerData>()
            .AsCached()
            ;



    }
}
