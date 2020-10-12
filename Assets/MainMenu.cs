using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button firstButton = null;
    [SerializeField] Toggle player1 = null;
    [SerializeField] Toggle player2 = null;
    [SerializeField] GameObject help1Player = null;
    [SerializeField] GameObject help2Players = null;

    // Start is called before the first frame update
    void Start() {
        firstButton.Select();
    }

    public void PlayButton() {
        if (player1.isOn) {
            Debug.Log("Play with 1 player");
            GameManager.SinglePlayer = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("conduccion9");
        }
        else if (player2.isOn) {
            Debug.Log("Play with 2 player");
            GameManager.SinglePlayer = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("conduccion9");
        }
        else {
            Debug.Log("Plz select a game mode");
        }
    }

    public void GoToCredits() {
         UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void OnGameModeSelected(bool status) {
        help1Player.SetActive(player1.isOn);
        help2Players.SetActive(player2.isOn);
    }

    public void OnExitButton() {
        Debug.Log("Exit");
    }
}
