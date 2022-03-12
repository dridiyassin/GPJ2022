using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{

    public GameObject item1;
    public GameObject item2;

    public GameObject outPutItem;
    public float itemMixedScore;

    public Transform outPutSpawnPos;

    private ItemStats itemStats1;
    private ItemStats itemStats2;

    ItemMixList itemsCatalog;
    private void Start()
    {
        itemsCatalog = GameObject.Find("Game Manager").GetComponent<ItemMixList>();
    }

    public void craftItem()
    {
        if (item1 != item2) { //check if items are no the same
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
                outPutItem = itemsCatalog.itemsListMix[i].resultItem;
                itemMixedScore = calculateScore();
                Instantiate(outPutItem, outPutSpawnPos.position, Quaternion.identity);
            }
        }
    }
    float calculateScore() //Score mta3 l mixed item
    {
        return ((itemStats1.itemScore1 * itemStats2.itemScore3) + (itemStats1.itemScore2 * itemStats2.itemScore1) + (itemStats1.itemScore3 * itemStats2.itemScore2));
    }
}
