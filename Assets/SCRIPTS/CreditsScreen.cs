using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    [SerializeField] float minTime = 5f;

    // Update is called once per frame
    void Update()
    {
        minTime -= Time.deltaTime;
        if (Input.anyKeyDown && minTime < 0) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
