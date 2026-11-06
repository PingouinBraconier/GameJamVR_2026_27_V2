using UnityEngine;
using UnityEngine.InputSystem.Haptics;

public class HammerCollision : MonoBehaviour
{

    [SerializeField] private GameTimer gameTimer;
    [Header("Sons")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip taupeHitSound;
    [SerializeField] private AudioClip tableHitSound;

    [Header("Score")]
    [SerializeField] private ScoreMultiple scoreManager;

    [Header("Vibrations VR")]
    [SerializeField] private VRVibrations vrVibrations;

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
                // On récupère le multiplicateur avant de calculer le score
                float currentMultiplier = scoreManager.multyplicator;

                scoreManager.AddScore();

                // On déclenche la vibration
                if (vrVibrations != null)
                {
                    vrVibrations.Vibrate(currentMultiplier);
                }
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

