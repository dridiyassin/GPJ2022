using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundSystem : MonoBehaviour
{

    public int playerRoundWins = 0;
    public int enemyRoundWins = 0;

    public int maxRounds;
    private static GameObject instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    void checkMatchWinner()
    {
        if(playerRoundWins >= maxRounds)
        {
            //Player wins
        } else if(enemyRoundWins >= maxRounds)
        {
            //Enemy WIns
        }
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
