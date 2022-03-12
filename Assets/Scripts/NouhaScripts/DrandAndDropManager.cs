using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrandAndDropManager : MonoBehaviour
{
    private bool dragging , placed;
    private Vector2 offset, originalPos;
    private GameObject slot;
    Rigidbody2D gravity;

    private void Awake()
    {
        originalPos = transform.position;
    }
    private void Start()
    {
        gravity = gameObject.GetComponent<Rigidbody2D>();

        //gravity.gravityScale = 0;

        slot = GameObject.Find("Slot");
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
    }
    private void OnMouseUp()
    {
        if (placed)
        {
            //Cursor.visible = false;

          var chosenObject =   Instantiate(Resources.Load<GameObject>("PrefabsNouha/Dragable/" + this.name) , slot.transform.position , Quaternion.identity)  ;
            chosenObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(gameObject);

            //instantiate fi blasa mta3 e slot
            dragging = false;

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
        if (other.gameObject.CompareTag("Slot"))
        {
            placed = true;

        }
        else { placed = false; }
        
    }
}
