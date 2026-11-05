using UnityEngine;
using UnityEngine.InputSystem;

public class HammerGrab : MonoBehaviour
{
    [SerializeField] private GameObject hammerSol;
    [SerializeField] private GameObject hammerMain;

    private bool hasHammer = false;

    void Start()//marteau par terre visible celui dans la main = invisible 
    {
        hammerSol.SetActive(true);
        hammerMain.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.gKey.wasPressedThisFrame)
        {
            if (!hasHammer)
            {
                // on prend le marteau
                hammerSol.SetActive(false);
                hammerMain.SetActive(true);

                hasHammer = true;

                Debug.Log("Marteau récup !");
            }
            else
            {
                // on repose le marteau 
                hammerMain.SetActive(false);
                hammerSol.SetActive(true);

                hasHammer = false;

                Debug.Log("Marteau reposé !");
            }
        }
    }
}