using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 velocity = Vector3.zero;

    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position += velocity;
        }
    }
}