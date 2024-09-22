using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    private float x;
    private float z;



    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");


        transform.position += new Vector3(x, 0, z) * Time.deltaTime * speed;

    }
}
