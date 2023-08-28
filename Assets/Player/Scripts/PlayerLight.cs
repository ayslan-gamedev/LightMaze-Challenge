using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class PlayerLight : MonoBehaviour
{
    private Light2D playerLight;

    public void NormalizeLight()
    {
        playerLight.intensity = 1.5f;
        playerLight.pointLightOuterRadius = MAX_RADIUS;
    }

    public const float MAX_RADIUS = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponentInChildren<Light2D>();

        NormalizeLight();
    }

    public float eraseSpeed;

    void EraseLight()
    {
        playerLight.pointLightOuterRadius = math.clamp(playerLight.pointLightOuterRadius -= eraseSpeed * Time.deltaTime, 0, MAX_RADIUS);
        
        if(playerLight.pointLightOuterRadius <= MAX_RADIUS / 4)
        {
            playerLight.intensity = math.clamp(playerLight.intensity -= (eraseSpeed / 2) * Time.deltaTime, 0, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EraseLight();
    }
}