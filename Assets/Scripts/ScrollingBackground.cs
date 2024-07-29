using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingBackground : MonoBehaviour
{
    public float moveSpeedY;
    public int indexScene;
    private MeshRenderer meshrenderer;
    public KeyData kd;

    // Start is called before the first frame update
    void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshrenderer.material.mainTextureOffset = new Vector2(0f, Time.realtimeSinceStartup * -moveSpeedY);
    }
    public void Stop()
    {
        moveSpeedY = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        { 
            ImageFader imf = GameObject.FindWithTag("ImageFader").GetComponent<ImageFader>();
            imf.FadeToBlack();
            Invoke("Reload", 2f);
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(indexScene);
        kd.key1 = false;
        if (kd.keysObtained > 0)
        {
            kd.keysObtained--;
        }
    }
}
