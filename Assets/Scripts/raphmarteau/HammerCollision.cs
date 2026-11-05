using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    [Header("Sons")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip taupeHitSound;
    [SerializeField] private AudioClip tableHitSound;

    private void OnTriggerEnter(Collider other)//collision entrante 
    {
        TargetUpAndDown target = other.GetComponentInParent<TargetUpAndDown>();

        if (target != null)
        {
            Debug.Log("Taupe touchée !");

            if (audioSource != null && taupeHitSound != null)
            {
                audioSource.PlayOneShot(taupeHitSound);
            }
            target.DownOnHit();

            return;
        }

        if (other.CompareTag("ArcadeTable"))// son table
        {
            Debug.Log("Table touchée !");

            if (audioSource != null && tableHitSound != null)
            {
                audioSource.PlayOneShot(tableHitSound);
            }
        }
    }
}

