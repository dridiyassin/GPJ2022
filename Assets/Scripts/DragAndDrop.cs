using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Mixer mixerScript;
    // For now its just a click to mix , Taw ba3d ngedou drag & drop kemel
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(mixerScript.item1 == null)
            {
                mixerScript.item1 = Resources.Load<GameObject>("Prefabs/" + gameObject.name);
                mixerScript.updateItemStats1();
            }
            else
            {
                
                    mixerScript.item2 = Resources.Load<GameObject>("Prefabs/" + gameObject.name);

                    mixerScript.updateItemStats2();
                if (mixerScript.item1 != mixerScript.item2) //CHECK IF ITEMS ARE NOT THE SAME
                {
                    mixerScript.enemyAutoMix(); //ysir l craft mta3 l enemy 9bal bch mayaamlsh craft 9bal may3amer l Items
                    mixerScript.craftItem();
                }
                

            }
            
        }
    }
}
