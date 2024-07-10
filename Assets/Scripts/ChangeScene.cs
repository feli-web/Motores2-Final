using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;
    ImageFader imFader;
    void Start()
    {
        imFader = GameObject.FindWithTag("ImageFader").GetComponent<ImageFader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = transform.position;
            other.GetComponent<PlayerMovement>().Freeze();
            imFader.FadeToBlack();
            Invoke("Transport", 2);
        }
    }
    public void Transport()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
