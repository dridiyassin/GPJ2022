using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrandAndDropManager : MonoBehaviour
{
    public bool isFromPrefab = false;

    private bool dragging , placed , bowling;
    private Vector2 offset, originalPos;
    private GameObject slot;
    Rigidbody2D gravity;
    public Mixer mixerScript;
     AudioSource audio;

    private void Awake()
    {
        originalPos = transform.position;
        
    }
    private void Start()
    {
        gravity = gameObject.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        

        slot = GameObject.Find("fleche");
        bowling = false;
        placed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging)
            return;
        if (placed)
            return;

        var mousePosition = GetMousePos();
        transform.position = mousePosition;
        
    }

    private void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        audio.Play();
    }
    private void OnMouseUp()
    {
        if (placed)
        {

            GameObject toSpawn = Resources.Load<GameObject>("PrefabsNouha/Dragable/" + this.name);
            GameObject chosenObject = Instantiate(toSpawn, slot.transform.position, Quaternion.identity);
            DrandAndDropManager dAndD = chosenObject.GetComponent<DrandAndDropManager>();
            dAndD.mixerScript = mixerScript;
            dAndD.isFromPrefab = true;
            chosenObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            
            gravity.gravityScale = 1;

            Destroy(gameObject);





            //instantiate fi blasa mta3 e slot
            dragging = false;
            if (bowling)
            {
                Debug.Log("bowling");
                Destroy(chosenObject);

            }

        }
        else
        {
            transform.position = originalPos;
            dragging = false;
        }
        
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Arrow"))
        {
            if (!isFromPrefab)
            {
                placed = true;
            }

        }
        if (other.gameObject.CompareTag("Pot"))
        {
            if (isFromPrefab)
            {
                if (mixerScript.item1 == null)
                {
                    
                    string objName = this.name;
                    objName = objName.Replace("(Clone)", "");
                    mixerScript.item1 = Resources.Load<GameObject>("PrefabsNouha/Dragable/" + objName);
                    mixerScript.updateItemStats1();
                    Destroy(gameObject);


                }
                else
                {
                    string objName = this.name;
                    objName = objName.Replace("(Clone)", "");
                    mixerScript.item2 = Resources.Load<GameObject>("PrefabsNouha/Dragable/" + objName);

                    mixerScript.updateItemStats2();
                    if (mixerScript.item1 != mixerScript.item2) //CHECK IF ITEMS ARE NOT THE SAME
                    {
                        mixerScript.enemyAutoMix(); //ysir l craft mta3 l enemy 9bal bch mayaamlsh craft 9bal may3amer l Items
                        mixerScript.craftItem();
                        //mixerScript.findWinner();
                        Destroy(gameObject);
                    }

                    Destroy(gameObject);
                }

            }
        }
        //else
        //{
        //    placed = false;
        //}
    }
    
   
}
