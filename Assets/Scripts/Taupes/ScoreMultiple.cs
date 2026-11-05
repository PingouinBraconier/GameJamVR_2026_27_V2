using UnityEngine;

public class ScoreMultiple : MonoBehaviour
{
    private float score;
    private float multyplicator = 1;
    private float points = 1;
    private bool isGold;
    private bool isRed;

    public void AddScore()
    {
        if (isGold == true)
        {
            points = 5;
        }
        else if (isRed == true)
        {
            points = -1;
        }
        else
        {
            points = 1;
        }
        score = score + points * multyplicator;
        multyplicator = multyplicator + 1;
    }

    public void ResetMultyplicator()
    {
        multyplicator = 1;
    }
    
}
