using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool gameOver;
    public GameObject gameOverUI;

    void Start()
    {
        gameOver = false;
    }

	void Update()
    {
        if (gameOver)
            return;

        if(PlayerVariables.Lives <= 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
