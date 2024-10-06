using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public interface IBeginSceneView
{
    event Action OnBeginView;
    event Action OnClick;


    void BeginView();

    void ClickView();

    void LoadingSceneView(int sceneId);
}

public abstract class BeginSceneViewBase : MonoBehaviour, IBeginSceneView
{
    [SerializeField] private Animator _animator;

    public event Action OnBeginView;
    public event Action OnClick;

    public abstract string PATH_BEGIN_VIEW { get; }
    public abstract string PATH_END_VIEW { get; }

    public virtual void BeginView()
    {

        if (string.IsNullOrEmpty(PATH_BEGIN_VIEW)) throw new Exception($"Path Empty {nameof(PATH_BEGIN_VIEW)}");

        _animator.SetTrigger(PATH_BEGIN_VIEW);

        OnBeginView?.Invoke();
    }

    public virtual void ClickView()
    {

        if (string.IsNullOrEmpty(PATH_END_VIEW)) throw new Exception($"Path Empty {nameof(PATH_END_VIEW)}");
        _animator.SetTrigger(PATH_END_VIEW);

        OnClick?.Invoke();
    }

    public void LoadingSceneView(int sceneId)
    {

        if (sceneId < 0)
        {
            throw new Exception($"{nameof(sceneId)} not correct");
        }

        LoadingSceneHandler.Instance.LoadScene(sceneId);
    }
}
