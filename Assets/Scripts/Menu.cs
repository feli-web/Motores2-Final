using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    ImageFader imFader;
    public GameObject[] menuElements;
    public KeyData kd;

    void Start()
    {
        imFader = GameObject.FindWithTag("ImageFader").GetComponent<ImageFader>();
        Invoke("Appear", 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void New()
    {
        imFader.FadeToBlack();
        Invoke("ChangeScene", 2f);
        Invoke("DisAppear", 0f);
        kd.key1 = false;
        kd.key2 = false;
        kd.key3 = false;
        kd.key4 = false;
        kd.keysObtained = 0;
    }
    public void Load()
    {
        if (kd.keysObtained != 0)
        {
            imFader.FadeToBlack();
            Invoke("ChangeScene", 2f);
            Invoke("DisAppear", 0f);
            kd.Load();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
    void Appear()
    {
        for (int i = 0; i < menuElements.Length; i++)
        {
            menuElements[i].SetActive(true);
        }
    }
    void DisAppear()
    {
        for (int i = 0; i < menuElements.Length; i++)
        {
            menuElements[i].SetActive(false);
        }
    }
}
