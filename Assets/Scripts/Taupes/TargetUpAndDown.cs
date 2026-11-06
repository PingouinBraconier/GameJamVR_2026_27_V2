
using UnityEngine;
using System.Collections;

public class TargetUpAndDown : MonoBehaviour
{
    private Vector3 upPosition;
    private Vector3 downPosition;
    private float timer;
    private bool isUp;
    private float dureeMax = 0.25f;
    private float tempsEcoule;
    private float duree;
    public float mutiplicateurDificulte = 1;
    private bool sonEchecJoue = false;
    private bool sonSortieJoue = false;
    [SerializeField] public float timerMax;
    private bool isReady;
    [SerializeField] private Collider taupeColider;
    [SerializeField] private MultiplicatorUI multiplicatorUI;
    [SerializeField] private ScoreMultiple scoreManager;
    [SerializeField] private LEDSequence[] ledManager;

    [Header("Sons de la taupe")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonSortie;

    [SerializeField] private AudioClip sonsEchec;


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
            StartCoroutine(DescendreTaupe());
            taupeColider.enabled = false;
            multiplicatorUI.upMulti();
            sonSortieJoue = false;
            sonEchecJoue = false;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            tempsEcoule += Time.deltaTime;
            duree = tempsEcoule * mutiplicateurDificulte / dureeMax;
            if (isUp == true)
            {
                // Son joué une seule fois au début de la descente
                if (!sonEchecJoue)
                {
                    if (audioSource != null && sonsEchec != null)
                    {
                        audioSource.PlayOneShot(sonsEchec);
                    }

                    sonEchecJoue = true;
                }

                gameObject.transform.position = Vector3.Lerp(upPosition, downPosition, duree);
                taupeColider.enabled = false;

                scoreManager.ResetMultyplicator();
                ledManager[0].PlayFailed();
                ledManager[1].PlayFailed();
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
                    // Début de la montée
                    if (!sonSortieJoue)
                    {
                        if (audioSource != null && sonSortie != null)
                        {
                            audioSource.PlayOneShot(sonSortie);
                        }

                        sonSortieJoue = true;
                    }

                    gameObject.transform.position = Vector3.Lerp(downPosition, upPosition, duree);
                    taupeColider.enabled = true;
                }
            }
            if (duree > 1)
            {
                isReady = false;

                // Si la taupe vient de terminer sa descente
                if (isUp == true)
                {
                    sonSortieJoue = false;
                    sonEchecJoue = false;
                }

                isUp = !isUp;
                timer = 0;
                tempsEcoule = 0;

                Debug.Log("scoreReset");
            }
        }
        
    }

    IEnumerator DescendreTaupe()
    {
        for (int i = 1; i <= 4; i++)
        {
            float progression = i / 4f;

            transform.position = Vector3.Lerp(
                upPosition,
                downPosition,
                progression
            );

            yield return new WaitForSeconds(0.025f);  
        }
    }
}
