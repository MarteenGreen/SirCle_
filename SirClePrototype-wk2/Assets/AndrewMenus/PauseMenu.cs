using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject pause;
    public GameObject settings;

    private bool paused;
    private bool isPause;
    private bool isSetting;

	// Use this for initialization
	void Start () {
        paused = false;
        isPause = false;
        if(!pauseMenu)
            pauseMenu = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            isPause = paused;
        }

        if (paused)
        {
            pauseMenu.SetActive(true);
            if (isPause)
            {
                pause.SetActive(true);
                settings.SetActive(false);
            }
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        
        settings.SetActive(true);
        isSetting = true;
        pause.SetActive(false);
        isPause = false;
    }

    public void setSetting(bool state)
    {
        isSetting = state;
    }
    public void setPause(bool state)
    {
        isPause = state;
    }
}
