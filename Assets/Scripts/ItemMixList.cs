using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMixList : MonoBehaviour
{

    //ITEMS CATALOG , t3abi possible craftings lahne 
    [System.Serializable]
    public class ItemCombList
    {
        public GameObject item1;
        public GameObject item2;
        public GameObject resultItem;
    }
    public ItemCombList[] itemsListMix;
}
