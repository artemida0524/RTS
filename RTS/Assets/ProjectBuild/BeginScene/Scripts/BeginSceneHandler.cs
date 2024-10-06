using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BeginSceneHandler : MonoBehaviour
{
    private IBeginSceneView _view;

    [Inject]
    private void Construct(IBeginSceneView view)
    {
        this._view = view;
    }


    private void Start()
    {
        _view.BeginView();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _view.ClickView();
        }
    }

}

