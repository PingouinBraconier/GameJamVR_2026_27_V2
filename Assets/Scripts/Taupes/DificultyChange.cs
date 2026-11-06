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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void EasyMode()
    {
        taupeParams1.mutiplicateurDificulte = 1f;
        taupeParams2.mutiplicateurDificulte = 1f;
        taupeParams3.mutiplicateurDificulte = 1f;
        taupeParams4.mutiplicateurDificulte = 1f;
        taupeParams5.mutiplicateurDificulte = 1f;
        taupeParams6.mutiplicateurDificulte = 1f;
    }
    public void NormalMode()
    {
        taupeParams1.mutiplicateurDificulte = 1.5f;
        taupeParams2.mutiplicateurDificulte = 1.5f;
        taupeParams3.mutiplicateurDificulte = 1.5f;
        taupeParams4.mutiplicateurDificulte = 1.5f;
        taupeParams5.mutiplicateurDificulte = 1.5f;
        taupeParams6.mutiplicateurDificulte = 1.5f;

    }
    public void HardMode()
    {
        taupeParams1.mutiplicateurDificulte = 100f;
        taupeParams2.mutiplicateurDificulte = 100f;
        taupeParams3.mutiplicateurDificulte = 100f;
        taupeParams4.mutiplicateurDificulte = 100f;
        taupeParams5.mutiplicateurDificulte = 100f;
        taupeParams6.mutiplicateurDificulte = 100f;
    }
}
