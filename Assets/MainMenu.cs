using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button firstButton = null;
    [SerializeField] Toggle player1 = null;
    [SerializeField] Toggle player2 = null;
    [SerializeField] GameObject help1Player = null;
    [SerializeField] GameObject help2Players = null;
    [SerializeField] float minTimeToLoad = 2.0f;
    [SerializeField] GameObject loadingScreen = null;

    // Start is called before the first frame update
    void Start() {
        firstButton.Select();
    }

    public void PlayButton() {
        if (player1.isOn) {
            GameManager.SinglePlayer = true;
            SceneManager.LoadScene("conduccion9");
        }
        else if (player2.isOn) {
            GameManager.SinglePlayer = false;
            SceneManager.LoadScene("conduccion9");
        }
        else {
        }
    }

    public void GoToCredits() {
         SceneManager.LoadScene("Credits");
    }

    public void OnGameModeSelected(bool status) {
        help1Player.SetActive(player1.isOn);
        help2Players.SetActive(player2.isOn);
    }

    public void OnExitButton() {
        Debug.Log("Exit");
    }

    IEnumerator PreloadScene(string scene)
    {
        float loadingProgress;
        float timeLoading = 0;
        yield return null;
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                timeLoading += Time.deltaTime;
                loadingProgress = ao.progress + 0.1f;
                loadingProgress = loadingProgress * timeLoading / minTimeToLoad;

                // Loading completed
                if (loadingProgress >= 1)
                {
                    loadingScreen.SetActive(false);
                    ao.allowSceneActivation = true;

                }
                yield return null;
            }
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }
}
