using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshSurface))]
public class UpdateSurface : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;
    private float time = 0f;
    private float timeOut = 0.2f;

    private void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
    }


    private void Update()
    {
        time += Time.deltaTime;
        if (navMeshSurface != null && time > timeOut)
        {
            navMeshSurface.BuildNavMesh();
            time = 0f;
        }
    }



}
