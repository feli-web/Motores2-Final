
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI actionText;
    public string action;
    bool isOpen;
    public Key requiredKey;
    public KeyData keyData;
    public MeshRenderer mr;
    public Color color;

    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (IsButtonPressed(requiredKey))
        {
            mr.material.color = Color.black;
        }
        if (!IsButtonPressed(requiredKey))
        {
            mr.material.color = color;

            if (Input.GetKeyDown(KeyCode.N) && isOpen)
            {
                OpenDoor();
                actionText.enabled = false;
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
            if (!IsButtonPressed(requiredKey))
            {
                actionText.enabled = true;
                actionText.text = action;
                isOpen = true;
            }
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

    private bool IsButtonPressed(Key key)
    {
        switch (key)
        {
            case Key.key1:
                return keyData.key1;
            case Key.key2:
                return keyData.key2;
            case Key.key3:
                return keyData.key3;
            case Key.key4:
                return keyData.key4;
            default:
                return false;
        }
    }

}
public enum Key
{
    key1,
    key2,
    key3,
    key4
}
