using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private LEDSequence[] ledManager;
    private float timeRemaining = 60f;// durée
    private bool gameOver = false;
    public bool isGamStart;

    [Header("Musique de la partie")]
    [SerializeField] private AudioSource gameMusicSource;

    private bool musicStarted = false;


    public bool IsGameOver
    {
        get
        {
            return gameOver;
        }
    }

    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {

        // Déclenchement de la musique au début de la partie
        if (isGamStart && !musicStarted)
        {
            if (gameMusicSource != null)
            {
                gameMusicSource.loop = true;
                gameMusicSource.Play();
            }

            musicStarted = true;
        }


        if (isGamStart == true)
        {
            if (gameOver)
            {
                return;
            }

            timeRemaining -= Time.deltaTime;//temps qui reste et temps écoulé

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                gameOver = true;

                // Arrêt de la musique
                if (gameMusicSource != null)
                {
                    gameMusicSource.Stop();
                }

                // stop taupes
                TargetUpAndDown[] targets = FindObjectsByType<TargetUpAndDown>(FindObjectsSortMode.None);

                ledManager[0].Victory();
                ledManager[1].Victory();


                foreach (TargetUpAndDown target in targets)
                {
                    target.enabled = false;
                }

                Debug.Log("Fin de la partie !");
            }

            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int secondes = Mathf.CeilToInt(timeRemaining);

        int minutes = secondes / 60;
        int resteSecondes = secondes % 60;

        timerText.text = minutes.ToString("00") + ":" + resteSecondes.ToString("00");
    }
}