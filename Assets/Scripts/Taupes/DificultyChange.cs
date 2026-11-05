using UnityEngine;

public class DificultyChange : MonoBehaviour
{
    [SerializeField] private TargetUpAndDown taupeParams;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void EasyMode()
    {
        taupeParams.timerMax = 1.5f;
    }
    public void NormalMode()
    {
        taupeParams.timerMax = 1f;
    }
    public void difficile()
    {
        taupeParams.timerMax = 0.25f;
    }
}
