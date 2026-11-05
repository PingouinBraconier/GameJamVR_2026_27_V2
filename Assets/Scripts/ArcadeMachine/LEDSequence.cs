using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LEDSequence : MonoBehaviour
{
    public Renderer[] leds;
    public Material materialOn;
    public Material materialOff;
    public Material materialVictory;
    public float delay = 0.2f;
    private Coroutine currentEffect;
    public LEDSequence ledSequence;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEffect = StartCoroutine(PlaySequence());
        StartCoroutine(TestVictory());
    }

    IEnumerator TestVictory()
    {
        yield return new WaitForSeconds(60f);

        PlayVictory();
    }

    IEnumerator PlaySequence()
    {
        foreach (Renderer led in leds)
        {
            led.sharedMaterial = materialOff;
        }

        while (true)
        {
            for (int i=0; i<leds.Length/2; i++)
            {
                foreach (Renderer led in leds)
                {
                    led.sharedMaterial = materialOff;
                }

                leds[i].sharedMaterial = materialOn;
                leds[i+5].sharedMaterial = materialOn;
                

                yield return new WaitForSeconds(delay);
            }
        }
    }

    void StopCurrentEffect()
    {
        if (currentEffect != null)
        {
            StopCoroutine(currentEffect);
        }
    }

    public void PlayVictory()
    {
        StopCurrentEffect();
        currentEffect = StartCoroutine(VictoryEffect());
    }

    IEnumerator VictoryEffect()
    {
        foreach(Renderer led in leds)
        {
            led.sharedMaterial = materialVictory;
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < 3; i++)
        {
            foreach (Renderer led in leds)
            {
                led.sharedMaterial = materialOff;
            }

            yield return new WaitForSeconds(0.2f);

            foreach (Renderer led in leds)
            {
                led.sharedMaterial = materialVictory;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
