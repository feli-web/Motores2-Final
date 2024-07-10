using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image image; // Reference to the UI Image component
    public float fadeDuration = 1.0f; // Duration of the fade

    private void Start()
    {
        if (image == null)
        {
            Debug.LogError("ImageFader: No Image component set.");
        }
        else
        {
            FadeToTransparent();
        }
    }

    // Function to fade image from transparent to black
    public void FadeToBlack()
    {
        StartCoroutine(FadeImage(Color.clear, Color.black));
    }

    // Function to fade image from black to transparent
    public void FadeToTransparent()
    {
        StartCoroutine(FadeImage(Color.black, Color.clear));
    }

    private IEnumerator FadeImage(Color startColor, Color endColor)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        image.color = endColor; // Ensure the final color is set
    }
}
