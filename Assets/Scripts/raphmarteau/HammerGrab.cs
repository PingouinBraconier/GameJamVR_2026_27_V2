
using UnityEngine;

public class HammerGrab : MonoBehaviour
{
    [Header("Marteau au sol")]
    [SerializeField] private GameObject hammerSol;

    [Header("Marteau dans les mains")]
    [SerializeField] private GameObject hammerMainDroite;
    [SerializeField] private GameObject hammerMainGauche;

    private enum MainQuiTient
    {
        Aucune,
        Droite,
        Gauche
    }

    private MainQuiTient mainActuelle = MainQuiTient.Aucune;

    void Start()
    {
        // Au départ, le marteau est au sol
        hammerSol.SetActive(true);

        hammerMainDroite.SetActive(false);
        hammerMainGauche.SetActive(false);

        mainActuelle = MainQuiTient.Aucune;
    }

    // Appelé lorsque le joueur appuie sur Grab avec la main droite
    public void GrabRight()
    {
        if (mainActuelle == MainQuiTient.Droite)
        {
            // Le joueur repose le marteau
            DropHammer();
        }
        else
        {
            // Le joueur prend le marteau avec la main droite
            TakeHammerRight();
        }
    }

    // Appelé lorsque le joueur appuie sur Grab avec la main gauche
    public void GrabLeft()
    {
        if (mainActuelle == MainQuiTient.Gauche)
        {
            // Le joueur repose le marteau
            DropHammer();
        }
        else
        {
            // Le joueur prend le marteau avec la main gauche
            TakeHammerLeft();
        }
    }

    private void TakeHammerRight()
    {
        hammerSol.SetActive(false);
        hammerMainGauche.SetActive(false);

        hammerMainDroite.SetActive(true);

        mainActuelle = MainQuiTient.Droite;

        Debug.Log("Marteau pris avec la main droite !");
    }

    private void TakeHammerLeft()
    {
        hammerSol.SetActive(false);
        hammerMainDroite.SetActive(false);

        hammerMainGauche.SetActive(true);

        mainActuelle = MainQuiTient.Gauche;

        Debug.Log("Marteau pris avec la main gauche !");
    }

    private void DropHammer()
    {
        hammerMainDroite.SetActive(false);
        hammerMainGauche.SetActive(false);

        hammerSol.SetActive(true);

        mainActuelle = MainQuiTient.Aucune;

        Debug.Log("Marteau reposé au sol !");
    }
}
