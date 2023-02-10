using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterDelay : MonoBehaviour
{

[SerializeField]

private float time;

[SerializeField]

private string sceneName;

void Start()
    {
        Time.timeScale = 1f;
    }

public void LoadScene()
{
    StartCoroutine(DelaySceneLoad());
}

IEnumerator DelaySceneLoad()
{
    yield return new WaitForSeconds(time);
    SceneManager.LoadScene(sceneName);
}
}
