using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI actionText;
    public string action;
    bool isOpen;
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isOpen)
        {
            OpenDoor();
            actionText.enabled = false;
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
            actionText. enabled = true;
            actionText.text = action;
            isOpen = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isOpen == true)
            {
                CloseDoor();
                isOpen = false;
                actionText.enabled = false;
            }
            else
            {
                actionText.enabled = false;
            }
            
        }
    }

}
