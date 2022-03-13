using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundSystem : MonoBehaviour
{

    public int playerRoundWins = 0;
    public int enemyRoundWins = 0;

    public TextMeshProUGUI playerRoundsTMPro;
    public TextMeshProUGUI enemyRoundsTMPro;

    public int maxRounds;
    private static GameObject instance;

    public GameObject WinPanel;
    public GameObject LostPanel;

    public GameObject items;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
            playerRoundsTMPro.text = playerRoundWins.ToString();
            enemyRoundsTMPro.text = enemyRoundWins.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        items.SetActive(true);
        WinPanel.SetActive(false);
        LostPanel.SetActive(false);
    }
    bool checkMatchEndedAndWinner()
    {
        if(playerRoundWins >= maxRounds)
        {
            //Player wins
            Debug.Log("Player wins !");
            Cursor.visible = true;

            WinPanel.SetActive(true);
            items.SetActive(false);

            AudioSource win = WinPanel.GetComponent<AudioSource>();
            win.Play();


            return true;
        } else if(enemyRoundWins >= maxRounds)
        {
            //Enemy WIns
            Debug.Log("Enemy Wins !");
            Cursor.visible = true;
            LostPanel.SetActive(true);
            items.SetActive(false);
            AudioSource lost = LostPanel.GetComponent<AudioSource>();
            lost.Play();


            return true;
        }
        return false; //Match did not end
    }

    public void reloadGame()
    {
        playerRoundsTMPro.text = playerRoundWins.ToString();
        enemyRoundsTMPro.text = enemyRoundWins.ToString();
        if (!checkMatchEndedAndWinner())
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        playerRoundWins = 0;
        enemyRoundWins = 0;
        LostPanel.SetActive(false);
        items.SetActive(false);
        playerRoundsTMPro.text = playerRoundWins.ToString();
        enemyRoundsTMPro.text = enemyRoundWins.ToString();
        Destroy(gameObject);

    }
}
