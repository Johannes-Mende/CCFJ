using System.Collections;  // Listen
using System.Collections.Generic; // Coroutinen 
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool selfStart = false;

    private void Start()
    {
        if(selfStart)
        AsyncLoadingScene(1);
    }

    void ChangeLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void AsyncLoadingScene(int i)
    {
        StartCoroutine(LoadYourAsyncScene(i));
    }

    IEnumerator LoadYourAsyncScene(int i)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(i);
        //asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
            yield return null;
    }
}
