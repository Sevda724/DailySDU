using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image progressBar;
    public Slider slider;
    private void Start()
    {
        LevelLoader(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LevelLoader(int sceneIndex)
    {
        StartCoroutine(loadAsyncOperation(sceneIndex));

    }


    IEnumerator loadAsyncOperation(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (operation.progress < 10)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //slider.value = progress;
            progressBar.fillAmount = operation.progress;
            //yield return new WaitForSeconds(100);
            yield return new WaitForEndOfFrame();
            //yield return null;

        }

    }
}
