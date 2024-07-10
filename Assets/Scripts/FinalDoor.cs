using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public KeyData KeyData;
    bool key1;
    bool key2;
    bool key3;
    bool key4;

    Animator animator;
    TextMeshProUGUI actionText;
    public string action;
    bool isClose;

    void Start()
    {
        key1 = KeyData.key1;
        key2 = KeyData.key2;
        key3 = KeyData.key3;
        key4 = KeyData.key4;

        animator = GetComponent<Animator>();
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
        isClose = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isClose)
        {
            if (key1 && key2 && key3 && key4)
            {
                OpenDoor();
                actionText.enabled = false;

            }
            else
            {
                actionText.text = "Find all the keys to open the door";
            }
            
        }
    }

    void OpenDoor()
    {
        animator.Play("OpenDoor");
    }
    void CloseDoor()
    {
        animator.Play("CloseDoor");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = true;
            actionText.text = action;
            isClose = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = false;
            isClose = false ;
        }
    }
}
