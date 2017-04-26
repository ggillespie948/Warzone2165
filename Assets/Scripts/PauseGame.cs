using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public GameObject PauseUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("Pause");
            TogglePauseMenu();

        }
		
	}

    public void TogglePauseMenu()
    {
        if (PauseUI.activeSelf)
        {
            PauseUI.SetActive(false);
        } else
        {
            PauseUI.SetActive(true);
        }

        if (PauseUI.activeSelf)
        {
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
        } else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 1f;
        }

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;
        SceneManager.LoadScene("MainMenu");

    }
}
