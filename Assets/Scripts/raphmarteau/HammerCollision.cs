using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//interac entrante
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("Taupe touchée !");
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
