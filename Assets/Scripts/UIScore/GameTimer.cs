using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float timeRemaining = 60f;// durée
    private bool gameOver = false;

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
        if (gameOver)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;//temps qui reste et temps écoulé

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;

            // stop taupes
            TargetUpAndDown[] targets = FindObjectsByType<TargetUpAndDown>(FindObjectsSortMode.None);

            foreach (TargetUpAndDown target in targets)
            {
                target.enabled = false;
            }

            Debug.Log("Fin de la partie !");
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int secondes = Mathf.CeilToInt(timeRemaining);

        int minutes = secondes / 60;
        int resteSecondes = secondes % 60;

        timerText.text = minutes.ToString("00") + ":" + resteSecondes.ToString("00");
    }
}