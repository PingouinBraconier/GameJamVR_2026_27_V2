using System;
using Unity.Mathematics;
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
    [SerializeField] private float timerMax;
    private bool isReady;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upPosition = gameObject.transform.position;
        downPosition = upPosition - new Vector3(0, 1, 0);
        isUp = false;
        gameObject.transform.position = downPosition;
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
                }  
            }
            if (duree > 1)
            {
                isReady = false;
                isUp = !isUp;
                timer = 0;
                tempsEcoule = 0;
                
            }
        }
        
    }
}
