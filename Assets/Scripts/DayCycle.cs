using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayCycle : MonoBehaviour
{
    private static readonly int SkyboxTop = Shader.PropertyToID("_Top");
    private static readonly int SkyboxBottom = Shader.PropertyToID("_Bottom");
    
    [Header("Skybox")]
    [SerializeField] private Material dayTime;
    [SerializeField] private Material nightTime;
    
    [Header("Sun Intensity")]
    [SerializeField] private float dayTimeSunIntensity;
    [SerializeField] private float nightTimeSunIntensity;

    [Header("Flashlight")]
    [SerializeField] private Light flashlight;
    [SerializeField] private float dayTimeFlashlightIntensity;
    [SerializeField] private float nightTimeFlashlightIntensity;
    
    [Header("Dino Light")]
    [SerializeField] private Light dinoLight;
    [SerializeField] private float dayTimeDinoLightIntensity;
    [SerializeField] private float nightTimeDinoLightIntensity;
    
    [Space]
    [SerializeField, Range(0f, 1f)] private float time;

    private Light sun;
    
    private Color dayTimeTop;
    private Color dayTimeBottom;
    private Color nightTimeTop;
    private Color nightTimeBottom;


    private void Start()
    {
        sun = GetComponent<Light>();
        
        dayTimeTop = dayTime.GetColor(SkyboxTop);
        dayTimeBottom = dayTime.GetColor(SkyboxBottom);
        nightTimeTop = nightTime.GetColor(SkyboxTop);
        nightTimeBottom = nightTime.GetColor(SkyboxBottom);
    }

    private void OnValidate()
    {
        sun.intensity = Mathf.Lerp(dayTimeSunIntensity, nightTimeSunIntensity, time);
        flashlight.intensity = Mathf.Lerp(dayTimeFlashlightIntensity, nightTimeFlashlightIntensity, time);
        dinoLight.intensity = Mathf.Lerp(dayTimeDinoLightIntensity, nightTimeDinoLightIntensity, time);
        
        var topColor = Color.Lerp(dayTimeTop, nightTimeTop, time);
        var bottomColor = Color.Lerp(dayTimeBottom, nightTimeBottom, time);
        
        RenderSettings.skybox.SetColor(SkyboxTop, topColor);
        RenderSettings.skybox.SetColor(SkyboxBottom, bottomColor);
    }
}
