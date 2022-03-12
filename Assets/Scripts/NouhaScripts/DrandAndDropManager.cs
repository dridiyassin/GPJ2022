using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrandAndDropManager : MonoBehaviour
{
    public bool dragging , placed;
    public Vector2 offset, originalPos;
    public GameObject slot;

    private void Awake()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging)
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
            transform.position = slot.transform.position;
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
