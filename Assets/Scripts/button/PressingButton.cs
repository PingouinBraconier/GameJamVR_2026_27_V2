using UnityEngine;

public class PressingButton : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private DificultyChange dificultyChange;
    private float modeGame = 2;
    private Vector3 upPosition;
    private Vector3 downPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upPosition = gameObject.transform.position;
        downPosition = upPosition - new Vector3(0f, 0.01f, 0f);
        TargetUpAndDown[] targets = FindObjectsByType<TargetUpAndDown>(FindObjectsSortMode.None);
        foreach (TargetUpAndDown target in targets)
        {
            target.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = downPosition;
        if (gameObject.GetComponent<isStart>() == true)
        {
            StartGame();
            gameTimer.isGamStart = true;
            TargetUpAndDown[] targets = FindObjectsByType<TargetUpAndDown>(FindObjectsSortMode.None);
            foreach (TargetUpAndDown target in targets)
            {
                target.enabled = true;
            }
        }
        else if (gameObject.GetComponent<IsLeft>() == true)
        {
            LeftArrow();
        }
        else if(gameObject.GetComponent<IsRight>() == true)
        {
            RightArrow();
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.position = upPosition;
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
        if (modeGame == 3)
        {
            modeGame = 1;
        }
        else
        {
            modeGame = modeGame + 1;
        }
    }
    public void LeftArrow()
    {
        if (modeGame == 1)
        {
            modeGame = 3;
        }
        else
        {
            modeGame = modeGame - 1;
        }
    }
}
