using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoadingSceneHandler : MonoBehaviour
{
    public static LoadingSceneHandler Instance { get; private set; }
    private ILoadingScene _loadingScene;

    [Inject]
    private void Construct(ILoadingScene loadingScene)
    {
        this._loadingScene = loadingScene;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneEnumerator(sceneId));
    }

    private IEnumerator LoadSceneEnumerator(int sceneId)
    {
        yield return _loadingScene.Load(sceneId);
        SceneManager.LoadScene(sceneId);


        _loadingScene.EndLoad();
    }
}