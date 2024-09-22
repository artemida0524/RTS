using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RenderWall : MonoBehaviour
{
    public static RenderWall Instance { get; private set; }



    private void Awake()
    {
        Instance = this;
    }


    public void Renderer()
    {
        foreach (var item in InputGridFence.Instance.buildsReadOnly)
        {


            if (item.Value is BuildFence fence)
            {
                fence.EnableBottomWall(false);
                fence.EnableLeftWall(false);

                if (InputGridFence.Instance.buildsReadOnly.TryGetValue(new Vector3Int((int)fence.transform.position.x + 1, 0, (int)fence.transform.position.z), out BuildBase build))
                {
                    if (build is BuildFence)
                        (item.Value as BuildFence).EnableLeftWall(true);
                }

                if (InputGridFence.Instance.buildsReadOnly.TryGetValue(new Vector3Int((int)fence.transform.position.x, 0, (int)fence.transform.position.z - 1), out BuildBase build1))
                {
                    if (build1 is BuildFence)
                        (item.Value as BuildFence).EnableBottomWall(true);
                }
            }

        }
    }
}
