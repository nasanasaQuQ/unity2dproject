using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loading;

    public Slider slider;

    public Text progreassText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }

    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loading.SetActive(true);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progreassText.text = Mathf.FloorToInt(progress * 100f) + "%";
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
