using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    ImageFader imFader;
    public GameObject[] menuElements;

    void Start()
    {
        imFader = GameObject.FindWithTag("ImageFader").GetComponent<ImageFader>();
        Invoke("Appear", 2f);
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
