using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        SplashManager.LoadMainMenuScene += LoadMainMenuAtStart;
    }
    public void LoadMainMenuAtStart()
    {
        StartCoroutine(LoadAsynchronously(1));
    }
    public void LoadLevelAsynchronously(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }
    private void OnDisable()
    {
        SplashManager.LoadMainMenuScene -= LoadMainMenuAtStart;
    }
}
