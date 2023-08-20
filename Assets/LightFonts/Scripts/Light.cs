using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp : MonoBehaviour
{
    private Light2D lampLight;

    public bool turnOffOnPlayerExit;

    private void Start()
    {
        lampLight = GetComponentInChildren<Light2D>();
        ChangeLamp(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ChangeLamp(true);
        }
        else
        {
            ChangeLamp(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && turnOffOnPlayerExit)
        {
            ChangeLamp(false);
        }
    }

    private void ChangeLamp(bool on)
    {
        lampLight.enabled = on;
    }
}