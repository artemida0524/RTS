using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class MoveController : MonoBehaviour
{
    private NavMeshAgent agent;


    private void Awake()
    {
         agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
        


        if(agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Debug.Log(NavMeshPathStatus.PathComplete);
        }
        if(agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            Debug.Log(NavMeshPathStatus.PathPartial); 
        }
        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Debug.Log(NavMeshPathStatus.PathInvalid);
        }
    }
}
