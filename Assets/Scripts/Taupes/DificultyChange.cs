using UnityEngine;
using TMPro;

public class DificultyChange : MonoBehaviour
{
    [SerializeField] private TargetUpAndDown taupeParams1;
    [SerializeField] private TargetUpAndDown taupeParams2;
    [SerializeField] private TargetUpAndDown taupeParams3;
    [SerializeField] private TargetUpAndDown taupeParams4;
    [SerializeField] private TargetUpAndDown taupeParams5;
    [SerializeField] private TargetUpAndDown taupeParams6;
    [SerializeField] private TextMeshPro dificultyName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void EasyMode()
    {
        taupeParams1.timerMax = 1.5f;
        taupeParams2.timerMax = 1.5f;
        taupeParams3.timerMax = 1.5f;
        taupeParams4.timerMax = 1.5f;
        taupeParams5.timerMax = 1.5f;
        taupeParams6.timerMax = 1.5f;
        dificultyName.text = "Easy";
        dificultyName.color = Color.green;
    }
    public void NormalMode()
    {
        taupeParams1.timerMax = 1f;
        taupeParams2.timerMax = 1f;
        taupeParams3.timerMax = 1f;
        taupeParams4.timerMax = 1f;
        taupeParams5.timerMax = 1f;
        taupeParams6.timerMax = 1f;
        dificultyName.text = "Normal";
        dificultyName.color = Color.darkBlue;
    }
    public void HardMode()
    {
        taupeParams1.timerMax = 0.25f;
        taupeParams2.timerMax = 0.25f;
        taupeParams3.timerMax = 0.25f;
        taupeParams4.timerMax = 0.25f;
        taupeParams5.timerMax = 0.25f;
        taupeParams6.timerMax = 0.25f;
        dificultyName.text = "Hard";
        dificultyName.color = Color.red;
    }
}
