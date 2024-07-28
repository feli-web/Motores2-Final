using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public bool isPressed;
    MeshRenderer mr;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            isPressed = true;
            mr.material.color = Color.green;
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            isPressed = false;
            mr.material.color = Color.red;

        }
    }
}
