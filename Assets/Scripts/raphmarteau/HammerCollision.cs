using UnityEngine;

public class HammerCollision : MonoBehaviour
{

    [SerializeField] private GameTimer gameTimer;
    [Header("Sons")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip taupeHitSound;
    [SerializeField] private AudioClip tableHitSound;

    [Header("Score")]
    [SerializeField] private ScoreMultiple scoreManager;

    private void OnTriggerEnter(Collider other)//collision entrante 
    {
        TargetUpAndDown target = other.GetComponentInParent<TargetUpAndDown>();

        if (target != null)
        {
            if (gameTimer != null && gameTimer.IsGameOver)
            {
                return;
            }
            Debug.Log("Taupe touchée !");

            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }

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

