using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghabra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 20f * Time.deltaTime);
    }
}
