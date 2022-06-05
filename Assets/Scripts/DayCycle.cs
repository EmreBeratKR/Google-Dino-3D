using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayCycle : MonoBehaviour
{
    private static readonly int SkyboxTop = Shader.PropertyToID("_Top");
    private static readonly int SkyboxBottom = Shader.PropertyToID("_Bottom");
    
    [Header("Skybox")]
    [SerializeField] private Material dayTime;
    [SerializeField] private Material nightTime;

    [Header("Night Background")]
    [SerializeField] private Transform nightBackground;

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

    [Header("Cycle Animation")]
    [SerializeField] private float cycleSpeed;
    
    private Light sun;
    
    private Color dayTimeTop;
    private Color dayTimeBottom;
    private Color nightTimeTop;
    private Color nightTimeBottom;
    
    private State state = State.DayTime;
    private float time;


    private void Start()
    {
        sun = GetComponent<Light>();
        
        dayTimeTop = dayTime.GetColor(SkyboxTop);
        dayTimeBottom = dayTime.GetColor(SkyboxBottom);
        nightTimeTop = nightTime.GetColor(SkyboxTop);
        nightTimeBottom = nightTime.GetColor(SkyboxBottom);
        
        SetDayTime();
    }

    [ContextMenu("Toggle Time")]
    public void ToggleTime()
    {
        if (state == State.DayTime)
        {
            SetNightTime();
            return;
        }
        
        SetDayTime();
    }
    
    private void Lerp()
    {
        nightBackground.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, time);
        
        sun.intensity = Mathf.Lerp(dayTimeSunIntensity, nightTimeSunIntensity, time);
        flashlight.intensity = Mathf.Lerp(dayTimeFlashlightIntensity, nightTimeFlashlightIntensity, time);
        dinoLight.intensity = Mathf.Lerp(dayTimeDinoLightIntensity, nightTimeDinoLightIntensity, time);
        
        var topColor = Color.Lerp(dayTimeTop, nightTimeTop, time);
        var bottomColor = Color.Lerp(dayTimeBottom, nightTimeBottom, time);
        
        RenderSettings.skybox.SetColor(SkyboxTop, topColor);
        RenderSettings.skybox.SetColor(SkyboxBottom, bottomColor);
    }

    private void SetDayTime()
    {
        StartCoroutine(Animator());
        
        IEnumerator Animator()
        {
            while (true)
            {
                time -= Time.deltaTime * cycleSpeed;

                if (time <= 0f)
                {
                    time = 0f;
                    Lerp();
                    state = State.DayTime;
                    break;
                }
                
                Lerp();
                
                yield return null;
            }
        }
    }
    
    private void SetNightTime()
    {
        StartCoroutine(Animator());
        
        IEnumerator Animator()
        {
            while (true)
            {
                time += Time.deltaTime * cycleSpeed;

                if (time >= 1f)
                {
                    time = 1f;
                    Lerp();
                    state = State.NightTime;
                    break;
                }
                
                Lerp();
                
                yield return null;
            }
        }
    }


    private enum State
    {
        DayTime,
        NightTime
    }
}
