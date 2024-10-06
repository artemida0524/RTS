using System;
using System.Collections;
using UnityEngine;

public interface ILoadingScene
{
    IEnumerator Load(int sceneId);
    void EndLoad();
}

public abstract class LoadingSceneBase : MonoBehaviour, ILoadingScene
{
    [SerializeField] protected Animator _animator;

    public abstract string LOAD { get; }
    public abstract string ENDLOAD { get; }



    public IEnumerator Load(int sceneId)
    {
        if (string.IsNullOrEmpty(LOAD)) throw new Exception($"Path null {nameof(LOAD)}");
        _animator.SetTrigger(LOAD);

        yield return new WaitForSeconds(1f);
    }
    public void EndLoad()
    {
        _animator.SetTrigger(ENDLOAD);
    }
}
