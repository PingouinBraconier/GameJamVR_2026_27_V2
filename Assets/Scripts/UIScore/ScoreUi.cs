using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreMultiple scoreManager;
    [SerializeField] private TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "Score : " + scoreManager.Score;
    }
}