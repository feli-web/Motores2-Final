using UnityEngine;

public class FireLights : MonoBehaviour
{
    public Light fireLight;
    private float baseIntensity;
    float intensityVariation = 0.5f;
    float flickerSpeed = 0.1f;
    public Color baseColor = Color.yellow;
    public Color flickerColor = Color.red;

    void Start()
    {
        baseIntensity = fireLight.intensity;
    }

    void Update()
    {
        fireLight.intensity = baseIntensity + Mathf.PerlinNoise(Time.time * flickerSpeed, 0) * intensityVariation;
        fireLight.color = Color.Lerp(baseColor, flickerColor, Mathf.PerlinNoise(Time.time * flickerSpeed * 2, 1));
    }
}

