using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class BootStrap : MonoBehaviour
{



    [Inject]
    private void Construct(IPlayerPrefsService[] servicesLoadSavePlayerPrefs)
    {
        foreach (var item in servicesLoadSavePlayerPrefs)
        {
            item.Load();
        }
    }

    private void Start()
    {
        SceneManager.LoadScene(1);
    }
}
