using UnityEngine;
using UnityEngine.Audio;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)//interac entrante
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("Taupe touchée !");
            if (audioSource != null)//son se lance si taupe touchèe
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)//interac sortante
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("Marteau éloigné de la taupe !");
        }
    }
}
