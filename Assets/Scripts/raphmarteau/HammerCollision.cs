using UnityEngine;
using UnityEngine.Audio;

public class HammerCollision : MonoBehaviour
{
    [Header("Sons")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip taupeHitSound;
    [SerializeField] private AudioClip tableHitSound;
    private void OnTriggerEnter(Collider other)//collision entrante
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("Taupe touchée !");
            if (taupeHitSound != null)
            {
                audioSource.PlayOneShot(taupeHitSound);
            }
        }

        if (other.CompareTag("ArcadeTable"))
        {
            Debug.Log("Table touchée !");

            if (tableHitSound != null)
                audioSource.PlayOneShot(tableHitSound);
        }
    }

    private void OnTriggerExit(Collider other)//collision sortante
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("Marteau éloigné de la taupe !");
        }
    }
}
