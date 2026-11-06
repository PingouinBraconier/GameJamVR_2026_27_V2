using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MultiplicatorUI : MonoBehaviour
{
    [SerializeField] private TMP_Text multi;
    [SerializeField] private ScoreMultiple scoreMultiple;
    private Vector3 downPosition;
    private Vector3 upPosition;
    private float duree;
    private float tempsEcoule;
    private float dureeMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multi.alpha = 0f;
        downPosition = gameObject.transform.position;
        upPosition = downPosition + new Vector3(0f, 0.2f, 0f);
        dureeMax = 1;
        DureeIncrased();
    }
    IEnumerator DureeIncrased()
    {
        yield return new WaitForSeconds(0.1f);
        tempsEcoule += 0.1f;
        duree = tempsEcoule / dureeMax;
        gameObject.transform.position = Vector3.Lerp(downPosition, upPosition, duree);
        if (duree > 1)
        {
            yield return new WaitForSeconds(1f);
            multi.alpha = 0f;
        }
    }

    // Update is called once per frame
    public void upMulti()
    {
        duree = 0;
        multi.alpha = 1f;
        multi.text = scoreMultiple.multyplicator + "X";
    }
}
