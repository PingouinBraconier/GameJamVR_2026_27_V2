
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class HammerGrab : MonoBehaviour
{
    [SerializeField] private GameObject hammerSol;
    [SerializeField] private GameObject hammerMain;

    private bool hasHammer = false;

    void Start()
    {
        hammerSol.SetActive(true);
        hammerMain.SetActive(false);

        Debug.Log("Marteau disponible au sol");
    }

    public void Grab()
    {


        if (!hasHammer)
        {
            hammerSol.SetActive(false);
            hammerMain.SetActive(true);

            hasHammer = true;

            Debug.Log("Marteau récupéré !");
        }
        else
        {
            hammerMain.SetActive(false);
            hammerSol.SetActive(true);

            hasHammer = false;

            Debug.Log("Marteau reposé !");
        }
    }
}