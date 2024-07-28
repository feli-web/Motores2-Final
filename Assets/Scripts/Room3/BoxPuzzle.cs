using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{
    public GameObject[] platform;
    public GameObject keyObject;
    private bool keySpawned = false;  // Add this line

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!keySpawned && AllPlatformsPressed())
        {
            Debug.Log("Key obtained");
            var a = Instantiate(keyObject, new Vector3(32, 1, 18), keyObject.transform.rotation);
            a.GetComponent<KeyObject>().keyType = KeyType.Key3;
            keySpawned = true;  // Set the flag to true
        }
    }

    private bool AllPlatformsPressed()
    {
        foreach (var plat in platform)
        {
            if (!plat.GetComponent<BoxCheck>().isPressed)
            {
                return false;
            }
        }
        return true;
    }
}
