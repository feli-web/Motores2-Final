using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key Data", menuName = "Key Data")]
public class KeyData : ScriptableObject
{
    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;
    public int keysObtained;

    public void Save()
    {
        PlayerPrefs.SetInt("Key1", key1 ? 1 : 0);
        PlayerPrefs.SetInt("Key2", key2 ? 1 : 0);
        PlayerPrefs.SetInt("Key3", key3 ? 1 : 0);
        PlayerPrefs.SetInt("Key4", key4 ? 1 : 0);
        PlayerPrefs.SetInt("KeysObtained", keysObtained);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        key1 = PlayerPrefs.GetInt("Key1", 0) == 1;
        key2 = PlayerPrefs.GetInt("Key2", 0) == 1;
        key3 = PlayerPrefs.GetInt("Key3", 0) == 1;
        key4 = PlayerPrefs.GetInt("Key4", 0) == 1;
        keysObtained = PlayerPrefs.GetInt("KeysObtained", 0);
    }

}
