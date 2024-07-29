using TMPro;
using UnityEngine;

public class OneButtonPuzzle : MonoBehaviour
{
    bool canPress;
    TextMeshProUGUI actionText;
    public string action;
    public TextMeshProUGUI answerText;
    public KeyData keyData;
    int answer;
    public GameObject keyObject;

    private void Start()
    {
        actionText = GameObject.FindWithTag("ActionText").GetComponent<TextMeshProUGUI>();
        actionText.enabled = false;
        SelectAnswer();
    }

    private void Update()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                actionText.enabled = false;
                WriteAnswer();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                CheckAnswer();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPress = true;
            actionText.enabled = true;
            actionText.text = action;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPress = false;
            actionText.enabled = false;
            answerText.text = string.Empty; // Mejor usar string.Empty en lugar de null
        }
    }

    public void SelectAnswer()
    {
        switch (keyData.keysObtained)
        {
            case 0:
                answer = 4;
                break;
            case 1:
                answer = 5;
                break;
            case 2:
                answer = 6;
                break;
            case 3:
                answer = 7;
                break;
        }
        Debug.Log("Answer: " + answer);
    }

    public void WriteAnswer()
    {
        if (string.IsNullOrEmpty(answerText.text))
        {
            answerText.text = "0";
        }
        else
        {
            int currentNumber = int.Parse(answerText.text);
            currentNumber = (currentNumber + 1) % 10; 
            answerText.text = currentNumber.ToString();
        }
    }

    public void CheckAnswer()
    {
        if (answerText.text == answer.ToString())
        {
            Debug.Log("Key Obtained");
            actionText.enabled = false;
            var a = Instantiate(keyObject, new Vector3(0, 1, 9), keyObject.transform.rotation);
            a.GetComponent<KeyObject>().keyType = KeyType.Key4;
            Destroy(gameObject, 1f);
        }
        else
        {
            actionText.enabled = true;
            actionText.text = "Wrong Answer"; 
            answerText.text = string.Empty; 
        }
    }
}
