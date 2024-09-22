using System;
using System.Collections.Generic;
using UnityEngine;

public class InputGridFence : MonoBehaviour
{
    public static InputGridFence Instance { get; private set; }


    private BuildBase currentBuild;
    private Ray ray;
    private Camera mainCamera;

    private Dictionary<Vector3Int, BuildBase> builds = new Dictionary<Vector3Int, BuildBase>();

    public IReadOnlyDictionary<Vector3Int, BuildBase> buildsReadOnly => builds;

    private Vector3Int currentPosition = Vector3Int.zero;

    private BuildBase lastBuild;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (currentBuild != null)
        {

            FollowBuild();

        }
    }

    


    public void SetCurrentBuild(BuildBase build)
    {
        IntantiateBuild(build);
    }

    private void IntantiateBuild(BuildBase build)
    {
        currentBuild = Instantiate(build);


        lastBuild = currentBuild;
    }




    private void FollowBuild()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "GroundBuild")
            {
                Vector3Int newVector3 = new Vector3Int((int)hit.point.x, 0, (int)hit.point.z);

                if (currentPosition != newVector3)
                {
                    currentPosition = newVector3;
                    currentBuild.transform.position = newVector3;

                    SetState();

                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (CanBuild(currentBuild))
                    {
                        SetBuild(currentBuild);
                        currentBuild.Build();


                        currentBuild = null;
                    }
                }
                if (Input.GetKey(KeyCode.LeftShift) && this.currentBuild == null)
                {
                    IntantiateBuild(this.lastBuild);
                }
            }
        }
    }

    private void SetState()
    {
        if (CanBuild(currentBuild))
        {
            currentBuild.CanBuilt();
        }
        else
        {
            currentBuild.DontBuild();
        }
    }

    private void SetBuild(BuildBase build)
    {
        for (int x = (int)build.transform.position.x; x < (int)build.transform.position.x + build.SizeX; x++)
        {
            for (int z = (int)build.transform.position.z; z < (int)build.transform.position.z + build.SizeZ; z++)
            {

                Debug.Log($"{x} {z}");

                builds[new Vector3Int(x, 0, z)] = build;
            }
        }
    }

    private bool CanBuild(BuildBase build)
    {

        for (int x = (int)build.transform.position.x; x < (int)build.transform.position.x + build.SizeX; x++)
        {
            for (int z = (int)build.transform.position.z; z < (int)build.transform.position.z + build.SizeZ; z++)
            {
                if (builds.TryGetValue(new Vector3Int(x, 0, z), out BuildBase findBuild))
                {
                    Debug.Log($"Dont build, here object - {findBuild}");
                    return false;
                }
            }
        }
        return true;
    }

    public void ResetBuild()
    {
        //if (currentBuild != null)
        //    Destroy(currentBuild.gameObject);

        //if (lastBuild != null)
        //    Destroy(lastBuild.gameObject);

        //currentBuild = null;
        //lastBuild = null;
    }

}
