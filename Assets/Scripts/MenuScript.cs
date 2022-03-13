using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator lizzars;

    int playGameSceneIndex;
    public void playGame(int buildIndex)
    {
        lizzars.SetTrigger("open");
        playGameSceneIndex = buildIndex;
        Invoke("loadGameScene", 1f);
    }
    
    void loadGameScene()
    {
        SceneManager.LoadScene(playGameSceneIndex);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    
}
