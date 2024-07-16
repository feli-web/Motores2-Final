using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{
    public GameObject[] platform;
    public GameObject keyObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platform[0].GetComponent<BoxCheck>().isPressed == true && platform[1].GetComponent<BoxCheck>().isPressed == true && platform[2].GetComponent<BoxCheck>().isPressed == true && platform[3].GetComponent<BoxCheck>().isPressed == true && platform[4].GetComponent<BoxCheck>().isPressed == true && platform[5].GetComponent<BoxCheck>().isPressed == true) 
        {
            Debug.Log("Key obtained");
            var a = Instantiate(keyObject, new Vector3(32, 1, 18), keyObject.transform.rotation);
            a.GetComponent<KeyObject>().keyType = KeyType.Key3;
        }
    }
}
