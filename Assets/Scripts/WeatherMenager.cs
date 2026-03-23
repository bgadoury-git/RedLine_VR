using System.Collections;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance { get; private set; }

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem rainParticles;
    [SerializeField] private ParticleSystem snowParticles;

    [Header("Audio")]
    [SerializeField] private AudioSource weatherAudioSource;
    [SerializeField] private AudioClip rainSound;
    [SerializeField] private AudioClip snowSound;

    [Header("Lighting")]
    [SerializeField] private Light sunLight;
    [SerializeField] private Color dayColor = new Color(1.00f, 0.95f, 0.85f);
    [SerializeField] private Color nightColor = new Color(0.10f, 0.10f, 0.25f);
    [SerializeField] private Color rainColor = new Color(0.50f, 0.55f, 0.65f);
    [SerializeField] private Color snowColor = new Color(0.85f, 0.88f, 1.00f);

    [Header("Skybox")]
    [SerializeField] private Material skyboxMaterial;
    [SerializeField] private Color skyDay = new Color(0.40f, 0.65f, 1.00f);
    [SerializeField] private Color skyNight = new Color(0.02f, 0.02f, 0.10f);
    [SerializeField] private Color skyCloudy = new Color(0.55f, 0.55f, 0.60f);
    [SerializeField] private Color skyRain = new Color(0.25f, 0.28f, 0.35f);
    [SerializeField] private Color skySnow = new Color(0.70f, 0.75f, 0.85f);

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void SetWeather(S_GetWeather.WeatherCategory category, bool isDay)
    {
        StopAllParticles();
        category = S_GetWeather.WeatherCategory.Rain; // Hard set to showcase
        switch (category)
        {
            case S_GetWeather.WeatherCategory.Clear:
                StopWeatherSound();
                ApplyLighting(isDay ? 1.2f : 0.05f, isDay ? dayColor : nightColor);
                ApplySky(isDay ? skyDay : skyNight);
                SetFog(false, Color.white, 0f);
                break;

            case S_GetWeather.WeatherCategory.Cloudy:
                StopWeatherSound();
                ApplyLighting(isDay ? 0.55f : 0.05f, isDay ? dayColor : nightColor);
                ApplySky(skyCloudy);
                SetFog(false, skyCloudy, 0f);
                break;

            case S_GetWeather.WeatherCategory.Rain:
                PlayWeatherSound(rainSound, 0.6f);
                Play(rainParticles, 350);
                ApplyLighting(0.30f, rainColor);
                ApplySky(skyRain);
                SetFog(true, new Color(0.40f, 0.42f, 0.48f), 0.025f);
                break;

            case S_GetWeather.WeatherCategory.HeavyRain:
                PlayWeatherSound(rainSound, 1.0f);
                Play(rainParticles, 600);
                ApplyLighting(0.15f, rainColor);
                ApplySky(skyRain);
                SetFog(true, new Color(0.30f, 0.30f, 0.35f), 0.045f);
                break;

            case S_GetWeather.WeatherCategory.Snow:
                PlayWeatherSound(snowSound, 0.4f);
                Play(snowParticles, 120);
                ApplyLighting(isDay ? 0.60f : 0.05f, snowColor);
                ApplySky(skySnow);
                SetFog(true, new Color(0.75f, 0.78f, 0.88f), 0.020f);
                break;

            case S_GetWeather.WeatherCategory.HeavySnow:
                PlayWeatherSound(snowSound, 0.7f);
                Play(snowParticles, 400);
                ApplyLighting(isDay ? 0.40f : 0.05f, snowColor);
                ApplySky(skySnow);
                SetFog(true, new Color(0.70f, 0.72f, 0.82f), 0.045f);
                break;
        }
    }

   
    private void PlayWeatherSound(AudioClip clip, float volume)
    {
        if (weatherAudioSource == null || clip == null) return;
        if (weatherAudioSource.clip == clip && weatherAudioSource.isPlaying) return;
        weatherAudioSource.clip = clip;
        weatherAudioSource.loop = false;
        weatherAudioSource.volume = volume;
        weatherAudioSource.Play();
    }

    private void StopWeatherSound()
    {
        if (weatherAudioSource == null) return;
        weatherAudioSource.Stop();
        weatherAudioSource.clip = null;
    }

    private void Play(ParticleSystem ps, int emissionRate)
    {
        if (ps == null) return;
        var emission = ps.emission;
        emission.rateOverTime = emissionRate;
        ps.Play();
    }

    private void StopAllParticles()
    {
        foreach (var ps in new[] { rainParticles, snowParticles })
            if (ps != null) ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    private void ApplyLighting(float intensity, Color color)
    {
        if (sunLight == null) return;
        StartCoroutine(SmoothLight(sunLight.intensity, intensity,
                                   sunLight.color, color, 2f));
    }

    private void ApplySky(Color target)
    {
        if (skyboxMaterial == null) return;
        StartCoroutine(SmoothSky(skyboxMaterial.GetColor("_Tint"), target, 2f));
    }

    private void SetFog(bool enabled, Color color, float density)
    {
        RenderSettings.fog = enabled;
        RenderSettings.fogColor = color;
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogDensity = density;
    }


    private IEnumerator SmoothLight(float fromI, float toI,
                                    Color fromC, Color toC, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float n = t / duration;
            if (sunLight != null)
            {
                sunLight.intensity = Mathf.Lerp(fromI, toI, n);
                sunLight.color = Color.Lerp(fromC, toC, n);
            }
            yield return null;
        }
    }

    private IEnumerator SmoothSky(Color from, Color to, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            if (skyboxMaterial != null)
                skyboxMaterial.SetColor("_Tint", Color.Lerp(from, to, t / duration));
            yield return null;
        }
    }
}