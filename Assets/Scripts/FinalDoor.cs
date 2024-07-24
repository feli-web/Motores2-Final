using TMPro;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public KeyData keyData;
    Animator animator;
    TextMeshProUGUI actionText;
    public string action;
    bool isClose;

    void Start()
    {
        animator = GetComponent<Animator>();
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
        isClose = false;
        UpdateKeysVisibility();
    }

    void Update()
    {
        UpdateKeysVisibility();

        if (Input.GetKeyDown(KeyCode.N) && isClose)
        {
            if (AllKeysCollected())
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

    void UpdateKeysVisibility()
    {
        key1.SetActive(keyData.key1);
        key2.SetActive(keyData.key2);
        key3.SetActive(keyData.key3);
        key4.SetActive(keyData.key4);
    }

    bool AllKeysCollected()
    {
        return keyData.key1 && keyData.key2 && keyData.key3 && keyData.key4;
    }

    void OpenDoor()
    {
        animator.Play("OpenDoor");
    }

    void CloseDoor()
    {
        animator.Play("CloseDoor");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = true;
            actionText.text = action;
            isClose = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            actionText.enabled = false;
            isClose = false;
            CloseDoor();
        }
    }
}
