using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectView : MonoBehaviour
{
    [SerializeField] private GameObject _selectedObject;


    public void Enable(bool enable)
    {
        _selectedObject.SetActive(enable);
    }

    
}
