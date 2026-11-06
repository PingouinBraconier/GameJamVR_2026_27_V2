
using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRVibrations: MonoBehaviour
{
    [Header("Manette qui tient le marteau")]
    [SerializeField] private XRNode controllerHand = XRNode.RightHand;

    [Header("Réglages vibrations")]
    [SerializeField] private float minIntensity = 0.15f;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float vibrationDuration = 0.12f;

    private InputDevice controller;

    void Start()
    {
        controller = InputDevices.GetDeviceAtXRNode(controllerHand);
    }

    public void Vibrate(float multiplier)// en gros au plus le multiplier est haut au plus la vibration augmente 
    {
        // Récupérer la manette si nécessaire
        if (!controller.isValid)
        {
            controller = InputDevices.GetDeviceAtXRNode(controllerHand);
        }

        if (!controller.isValid)
        {
            Debug.LogWarning("Manette VR introuvable !");
            return;
        }

        // Plus le multiplicateur augmente, plus la vibration est forte
        float intensity = Mathf.Clamp(0.4f + (multiplier - 1) * 0.2f,0.4f,1f);

        // Envoyer la vibration
        if (controller.TryGetHapticCapabilities(out HapticCapabilities capabilities)
            && capabilities.supportsImpulse)
        {
            controller.SendHapticImpulse(0, intensity, vibrationDuration);

            Debug.Log("Vibration : " + intensity);
        }
    }
}
