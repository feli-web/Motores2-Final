using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    bool canPress;
    public ButtonPuzzle buttonPuzzle;
    TextMeshProUGUI actionText;
    public string action;
    public int buttonNumber;
    public int number;
    public ButtonType requiredButton;
    public MeshRenderer mr;
    public Color color;

    private void Start()
    {
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
        actionText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && canPress)
        {
            actionText.enabled = false;
            buttonPuzzle.colorOrder.Add(number);
            buttonPuzzle.Press(buttonNumber);
        }
        if (IsButtonPressed(requiredButton))
        {
            mr.material.color = Color.white;
        }
        if (!IsButtonPressed(requiredButton))
        {
            mr.material.color = color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!IsButtonPressed(requiredButton))
            {
                canPress = true;
                actionText.enabled = true;
                actionText.text = action;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPress = false;
            actionText.enabled = false;
        }
    }

    private bool IsButtonPressed(ButtonType button)
    {
        switch (button)
        {
            case ButtonType.Button0:
                return buttonPuzzle.Button0;
            case ButtonType.Button1:
                return buttonPuzzle.Button1;
            case ButtonType.Button2:
                return buttonPuzzle.Button2;
            case ButtonType.Button3:
                return buttonPuzzle.Button3;
            default:
                return false;
        }
    }
}

// Enum for ButtonType
public enum ButtonType
{
    Button0,
    Button1,
    Button2,
    Button3
}
