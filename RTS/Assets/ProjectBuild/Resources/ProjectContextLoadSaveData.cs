using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextLoadSaveData : MonoInstaller
{
    


    public override void InstallBindings()
    {
        Container
            .Bind<IServicePlayerPrefs>()
            .To<ServicePlayerData>()
            .AsCached()
            ;
            
    }
}
