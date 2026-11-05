using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LEDSequence : MonoBehaviour
{
    public Renderer[] leds;
    public Material materialOn;
    public Material materialOff;
    public float delay = 0.2f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        foreach (Renderer led in leds)
        {
            led.sharedMaterial = materialOff;
        }

        while (true)
        {
            for (int i=0; i<leds.Length; i++)
            {
                foreach (Renderer led in leds)
                {
                    led.sharedMaterial = materialOff;
                }

                leds[i].sharedMaterial = materialOn;

                yield return new WaitForSeconds(delay);
            }
        }
    }
}
