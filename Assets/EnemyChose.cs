using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyItems;
    public GameObject item1;
    public GameObject item2;
    void Start()
    {
        
    }

    public void compareAndMove()
    {
        for (int i = 0; i < enemyItems.Length; i++)
        {
            if(item1.name == enemyItems[i].name)
            {
                enemyItems[i].GetComponent<Animator>().enabled = true;
                Destroy(enemyItems[i], 1.5f);
            }
            
        }
        for (int i = 0; i < enemyItems.Length; i++)
        {
            if (item2.name == enemyItems[i].name)
            {
                enemyItems[i].GetComponent<Animator>().enabled = true;
                Destroy(enemyItems[i], 1.5f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
