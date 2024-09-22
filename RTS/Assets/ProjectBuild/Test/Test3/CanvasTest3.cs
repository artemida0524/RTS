using UnityEngine;

public class CanvasTest3 : MonoBehaviour
{
    public void SetCurrentBuild(BuildBase build)
    {
        //InputGridFence.Instance.ResetBuild();
        InputGridFence.Instance.SetCurrentBuild(build);
    }
}
