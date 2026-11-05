using System;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class TargetUpAndDown : MonoBehaviour
{
    private Vector3 upPosition;
    private Vector3 downPosition;
    private float timer;
    private bool isUp;
    private float dureeMax = 0.25f;
    private float tempsEcoule;
    private float duree;
    [SerializeField] public float timerMax;
    private bool isReady;
    [SerializeField] private Collider taupeColider;

    [SerializeField] private ScoreMultiple scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        downPosition = gameObject.transform.position;
        upPosition = downPosition + new Vector3(0f, 0.2f, 0f);
        isUp = false;
        gameObject.transform.position = downPosition;
        taupeColider.enabled = false;
    }

    public void DownOnHit()
    {
        if (isUp == true)
        {
            isReady = false;
            isUp = false;
            timer = -1;
            tempsEcoule = 0;
            gameObject.transform.position = downPosition;
            taupeColider.enabled = false;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            tempsEcoule += Time.deltaTime;
            duree = tempsEcoule / dureeMax;
            if (isUp == true)
            {
                gameObject.transform.position = Vector3.Lerp(upPosition, downPosition, duree);
                taupeColider.enabled = false;
                scoreManager.ResetMultyplicator();
            }
            else
            {
                if (isReady == false)
                {
                    if (duree > 1)
                    {
                        if (UnityEngine.Random.Range(1, 4) == 3)
                        {
                            isReady = true;

                        }
                        timer = 0;
                        duree = 0;
                        tempsEcoule = 0;
                        Debug.Log("isReady" + isReady + "isUp" + isUp);
                    }   
                }
                else
                {
                    gameObject.transform.position = Vector3.Lerp(downPosition, upPosition, duree);
                    taupeColider.enabled = true;
                }  
            }
            if (duree > 1)
            {
                isReady = false;
                isUp = !isUp;
                timer = 0;
                tempsEcoule = 0;
                
                Debug.Log("scoreReset");


            }
        }
        
    }
}
