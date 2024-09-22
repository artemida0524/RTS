using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawGridTest3 : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i = -20; i < 20; i++)
        {
            for (int j = -20; j < 20; j++)
            {
                if (j % 2 != 0 && i % 2 == 0) Gizmos.color = new Color(0.1f, 0.1f, 0.1f, 0.2f);
                else Gizmos.color = new Color(0.7f, 0.7f, 0.7f, 0.2f);

                Gizmos.DrawCube(new Vector3(i, 0.05f, j), new Vector3(1, 0.2f, 1));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        
    }
}
