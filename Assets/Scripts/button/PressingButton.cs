using System.Threading;
using UnityEngine;

public class PressingButton : MonoBehaviour
{
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private DificultyChange dificultyChange;
    private float modeGame = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartGame()
    {
        if (modeGame == 1)
        {
            dificultyChange.EasyMode();
        }
        if (modeGame == 2)
        {
            dificultyChange.NormalMode();
        }
        else if (modeGame == 3)
        {
            dificultyChange.HardMode();
        }
    }
    public void RightArrow()
    {

    }
    public void LeftArrow()
    {

    }
}
