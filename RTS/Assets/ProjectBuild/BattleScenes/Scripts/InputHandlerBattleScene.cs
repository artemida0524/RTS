using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandlerBattleScene : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (UnitsData.Instance.SelectedUnit.Count > 0)
            {

                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    foreach (var item in UnitsData.Instance.SelectedUnit)
                    {
                        item.SetDestination(hitInfo.point);
                    }
                }



                UnitsData.Instance.RemoveAllSelectedUnits();
            }
            else
            {
                Debug.Log("no");
            }
        }
    }
}
