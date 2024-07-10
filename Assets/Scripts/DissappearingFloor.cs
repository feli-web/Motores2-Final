using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingFloor : MonoBehaviour
{
    public float dissappearingTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,dissappearingTime);
        }
    }
}
