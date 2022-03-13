using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public bool isEnemyMixer;
    public Mixer opponentMixer;

    public GameObject item1;
    public GameObject item2;

    public GameObject outPutItem;
    public float itemMixedScore;

    public Transform outPutSpawnPos;

    public ItemStats itemStats1;
    public ItemStats itemStats2;

    public AudioSource magicAudio;

    public GameObject ghta;
    public Transform ghtaPos;

    public GameObject foundItem;

    public bool finishedWait = false;


    ItemMixList itemsCatalog;
    private void Start()
    {
        itemsCatalog = GameObject.Find("Game Manager").GetComponent<ItemMixList>();
        Cursor.visible = true;
    }

    public void craftItem()
    {
        if (item1 != item2) { //check AGAIN if items are no the same
            findMixedItem();
            //Animation if possible
        }
        
    }

    public void updateItemStats1()
    {
        itemStats1 = item1.GetComponent<ItemStats>();
    }

    public void updateItemStats2()
    {
        itemStats2 = item2.GetComponent<ItemStats>();
    }

    void findMixedItem() //Tlawej 3al output item fel catalog eli mawjoud fel Game Manager.
    {
        for (int i = 0; i < itemsCatalog.itemsListMix.Length; i++)
        {
            if((item1 == itemsCatalog.itemsListMix[i].item1 && item2 == itemsCatalog.itemsListMix[i].item2) || (item1 == itemsCatalog.itemsListMix[i].item2 && item2 == itemsCatalog.itemsListMix[i].item1))
            {
                
                foundItem = itemsCatalog.itemsListMix[i].resultItem;
                Cursor.visible = false;
                StartCoroutine(Result());
                //outPutItem = foundItem;




            }
        }
    }

    IEnumerator Result() 
    {
        yield return new WaitForSeconds(2);

        GameObject ghtaa =  Instantiate(ghta, ghtaPos.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        Destroy(ghtaa);

        magicAudio.Play();
        outPutItem = Instantiate(foundItem, outPutSpawnPos.position, Quaternion.identity);
        itemMixedScore = calculateScore();
        outPutItem.GetComponent<Fight>().isEnemyMix = isEnemyMixer;
        findWinner();

    }

    public void findWinner()
    {
        if (itemMixedScore >= opponentMixer.itemMixedScore)
        {

            outPutItem.GetComponent<Fight>().isWinner = true;
            opponentMixer.outPutItem.GetComponent<Fight>().isWinner = false;
            Cursor.visible = true;


        }
        else
        {
            outPutItem.GetComponent<Fight>().isWinner = false;
            opponentMixer.outPutItem.GetComponent<Fight>().isWinner = true;
            Cursor.visible = true;

        }

    }
    public void enemyAutoMix()
    {
        Debug.Log("checking if im enemy");
        if (!isEnemyMixer)
        {
            Debug.Log("Iam enemy");
            opponentMixer.item1 = itemsCatalog.itemsListMix[Random.Range(0, itemsCatalog.itemsListMix.Length)].item1;
            opponentMixer.item2 = itemsCatalog.itemsListMix[Random.Range(0, itemsCatalog.itemsListMix.Length)].item2;
            EnemyChose moveItemsScript = GameObject.Find("--EnemysItems--").GetComponent<EnemyChose>();
            moveItemsScript.item1 = opponentMixer.item1;
            moveItemsScript.item2 = opponentMixer.item2;

            if (opponentMixer.item1 != opponentMixer.item2)
            {
                moveItemsScript.compareAndMove();
                opponentMixer.updateItemStats1();
                opponentMixer.updateItemStats2();
                opponentMixer.craftItem();
                
            }
            else
            {
                enemyAutoMix();
            }
        }
    }
    float calculateScore() //Score mta3 l mixed item
    {
        return ((itemStats1.itemScore1 * itemStats2.itemScore3) + (itemStats1.itemScore2 * itemStats2.itemScore1) + (itemStats1.itemScore3 * itemStats2.itemScore2));
    }
}
