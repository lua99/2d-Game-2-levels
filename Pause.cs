using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseMenuUi;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pausee();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;


    }

     void Pausee()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    
        public void QuitGame()
    {
        Application.Quit();
    }
    
}
