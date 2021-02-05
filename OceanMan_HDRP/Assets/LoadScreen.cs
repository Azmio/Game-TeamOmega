using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
public int sceneToLoadIndex;
public Slider progressBar;
AsyncOperation loadingOperation;

   void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoadIndex);
    }
    void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }

}