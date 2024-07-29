using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public KeyData keyData;
    public float rotationSpeed;
    public KeyType keyType; // Agrega esta l�nea
    GameObject keyText;

    void Start()
    {
        keyText = GameObject.FindWithTag("KeyText");
    }

    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SetKeyTrue(); // Llama al m�todo que maneja las llaves
            keyData.keysObtained++;
            keyText.GetComponent<Animator>().Play("KeyText");
        }
    }

    private void SetKeyTrue()
    {
        switch (keyType)
        {
            case KeyType.Key1:
                keyData.key1 = true;
                break;
            case KeyType.Key2:
                keyData.key2 = true;
                break;
            case KeyType.Key3:
                keyData.key3 = true;
                break;
            case KeyType.Key4:
                keyData.key4 = true;
                break;
        }
    }
}

public enum KeyType
{
    Key1,
    Key2,
    Key3,
    Key4
}
