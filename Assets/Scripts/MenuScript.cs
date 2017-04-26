using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public string quickPlayLevel = "Level1";

	public void QuickPlay()
    {
        Debug.Log("Loading Game..");
        SceneManager.LoadScene(quickPlayLevel);

    }

    public void Quit()
    {
        Debug.Log("Quiting Game..");
        Application.Quit();

    }
}
