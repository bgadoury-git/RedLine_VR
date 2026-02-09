using UnityEngine;

public class Wheater : MonoBehaviour
{
    private ParticleSystem rainSystem;
    private ParticleSystem snowSystem;
    private float timer = 0f;
    private float switchInterval = 5f;
    private bool isSnowing = true;

    void Start()
    {
        CreateRain();
        CreateSnow();
        rainSystem.Stop();
    }

    void CreateRain()
    {
        GameObject rainObject = new GameObject("Rain");
        rainObject.transform.position = new Vector3(0f, 50f, 0f);
        
        rainSystem = rainObject.AddComponent<ParticleSystem>();
        
        var main = rainSystem.main;
        main.startLifetime = 3f;
        main.startSpeed = 20f;
        main.startSize = 0.1f;
        main.startColor = new Color(0.7f, 0.8f, 1f, 0.5f);
        main.maxParticles = 10000;
        main.gravityModifier = 2f;
        main.simulationSpace = ParticleSystemSimulationSpace.World;

        var emission = rainSystem.emission;
        emission.rateOverTime = 2000f;

        var shape = rainSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = new Vector3(500f, 0.1f, 500f);

        var renderer = rainSystem.GetComponent<ParticleSystemRenderer>();
        renderer.renderMode = ParticleSystemRenderMode.Stretch;
        renderer.lengthScale = 2f;
        renderer.velocityScale = 0.1f;
        
        Material rainMaterial = new Material(Shader.Find("UI/Default"));
        rainMaterial.color = new Color(0.7f, 0.8f, 1f, 0.3f);
        renderer.material = rainMaterial;
    }

    void CreateSnow()
    {
        GameObject snowObject = new GameObject("Snow");
        snowObject.transform.position = new Vector3(0f, 50f, 0f);
        
        snowSystem = snowObject.AddComponent<ParticleSystem>();
        
        var main = snowSystem.main;
        main.startLifetime = 8f;
        main.startSpeed = 5f;
        main.startSize = new ParticleSystem.MinMaxCurve(0.4f, 0.8f);
        main.startColor = new Color(1f, 1f, 1f, 1f);
        main.maxParticles = 5000;
        main.gravityModifier = 0.3f;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.startRotation = new ParticleSystem.MinMaxCurve(0f, 360f * Mathf.Deg2Rad);

        var emission = snowSystem.emission;
        emission.rateOverTime = 1000f;

        var shape = snowSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = new Vector3(500f, 0.1f, 500f);

        var velocityOverLifetime = snowSystem.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(-1.5f, 1.5f);
        velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(-1.5f, 1.5f);

        var rotationOverLifetime = snowSystem.rotationOverLifetime;
        rotationOverLifetime.enabled = true;
        rotationOverLifetime.z = new ParticleSystem.MinMaxCurve(-90f * Mathf.Deg2Rad, 90f * Mathf.Deg2Rad);

        var renderer = snowSystem.GetComponent<ParticleSystemRenderer>();
        renderer.renderMode = ParticleSystemRenderMode.Billboard;
        
        Material snowMaterial = new Material(Shader.Find("UI/Default"));
        snowMaterial.color = new Color(1f, 1f, 1f, 1f);
        renderer.material = snowMaterial;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f;
            isSnowing = !isSnowing;

            if (isSnowing)
            {
                rainSystem.Stop();
                snowSystem.Play();
                Debug.Log("Switched to Snow");
            }
            else
            {
                snowSystem.Stop();
                rainSystem.Play();
                Debug.Log("Switched to Rain");
            }
        }
    }
}
