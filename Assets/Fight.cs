using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public GameObject fightEffect;
    public bool isEnemyMix;
    public bool isWinner;

    private GameObject tawla;
    private bool canMoveToMiddle = false;

    private RoundSystem roundScript;

    // Start is called before the first frame update
    void Start()
    {
        tawla = GameObject.Find("tawla");
        Invoke("jumpToMiddle", 1.5f);
        Invoke("spawnGhabra", 2.5f);
    }

    void jumpToMiddle()
    {
        canMoveToMiddle = true;
        roundScript = GameObject.Find("Game Manager").GetComponent<RoundSystem>();
    }
    void spawnGhabra()
    {
        GameObject ghabra = Instantiate(fightEffect, tawla.transform.position, Quaternion.identity);
        Destroy(ghabra, 2.4f);
        if (isWinner)
        {

            addRoundWin();
            Invoke("restartGame", 5f);

        }
        else
        {
            Destroy(gameObject, 2.5f);
        }
    }

    void restartGame()
    {
        roundScript.reloadGame();

    }

    void addRoundWin()
    {
        if (isEnemyMix)
        {
            roundScript.enemyRoundWins += 1;
        }
        else
        {
            roundScript.playerRoundWins += 1;
        }
    }
    void Update()
    {
        if (canMoveToMiddle)
        {
            transform.position = Vector3.Lerp(transform.position, tawla.transform.position, 1.5f * Time.deltaTime);
        }
        
    }
}
