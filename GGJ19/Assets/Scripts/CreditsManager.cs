using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        
    }

    public void loadScene(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void quitGame() { Application.Quit(); }
}
