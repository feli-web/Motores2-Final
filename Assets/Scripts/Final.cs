using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public Animator[] chestAnimators;
    public float timeToOpen;
    ImageFader imFader;
    void Start()
    {
        StartCoroutine(FinalScene());
        imFader = GameObject.FindWithTag("ImageFader").GetComponent<ImageFader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator FinalScene()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < chestAnimators.Length; i++)
        {
            chestAnimators[i].Play("OpenChest");
            yield return new WaitForSeconds(timeToOpen);
        }
        yield return new WaitForSeconds(2.5f);
        imFader.FadeToBlack();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

    }
}
