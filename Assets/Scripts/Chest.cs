using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;
    bool canOpen;
    TextMeshProUGUI actionText;
    public string action;

    void Start()
    {
        animator = GetComponent<Animator>();
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && canOpen)
        {
            OpenChest();
            actionText.enabled = false;
        }
    }

    void OpenChest()
    {
        animator.Play("OpenChest");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = true;
            actionText.text = action;
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = false;
            actionText.text = "";
            canOpen = false;
        }
    }
}
