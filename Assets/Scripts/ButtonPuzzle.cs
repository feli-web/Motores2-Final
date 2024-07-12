using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public bool Button0;
    public bool Button1;
    public bool Button2;
    public bool Button3;
    public List<int> colorOrder = new List<int>();

    void Update()
    {
        if (colorOrder.Count >= 4)
        {
            Check();
        }
    }

    public void Press(int num)
    {
        if (num == 0)
        {
            Button0 = true;
        }
        else if (num == 1)
        {
            Button1 = true;
        }
        else if (num == 2)
        {
            Button2 = true;
        }
        else if (num == 3)
        {
            Button3 = true;
        }
    }

    void Check()
    {
        if (colorOrder[0] == 3 && colorOrder[1] == 1 && colorOrder[2] == 4 && colorOrder[3] == 2)
        {
            Debug.Log("Key Obtained");
            // Add more logic here, like enabling an object or transitioning to a new state.
        }
        else
        {
            Debug.Log("Incorrect sequence");
            ResetButtons();
        }
        colorOrder.Clear(); // Clear the order list after checking
    }

    void ResetButtons()
    {
        Button0 = false;
        Button1 = false;
        Button2 = false;
        Button3 = false;
    }
}
