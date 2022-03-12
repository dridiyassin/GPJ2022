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
                mixerScript.craftItem();
            }
            
        }
    }
}
