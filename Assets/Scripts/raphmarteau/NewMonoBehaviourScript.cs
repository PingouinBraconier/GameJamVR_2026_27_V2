using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Taupe"))
        {
            Debug.Log("TAUPE FRAPPEE !");

            // Transmet l'information à la taupe
            other.SendMessageUpwards(
                "OnHammerHit",
                SendMessageOptions.DontRequireReceiver
            );
        }
    }
}