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
        kd.key1 = false;
        kd.key2 = false;
        kd.key3 = false;
        kd.key4 = false;
        kd.keysObtained = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        imFader.FadeToBlack();
        Invoke("ChangeScene", 2f);
        Invoke("DisAppear", 0f);
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
        menuElements[0].SetActive(true);
        menuElements[1].SetActive(true);
        menuElements[2].SetActive(true);
    }
    void DisAppear()
    {
        menuElements[0].SetActive(false);
        menuElements[1].SetActive(false);
        menuElements[2].SetActive(false);
    }
}
