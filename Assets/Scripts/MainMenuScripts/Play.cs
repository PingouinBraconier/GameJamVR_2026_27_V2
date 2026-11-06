
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Play : MonoBehaviour
{
    [SerializeField] AudioClip btnSound;
    [SerializeField] AudioSource buttonAudioSource;

    // Sound for menu buttons
    public void PlayButtonSound()
    {
        if (buttonAudioSource != null && btnSound != null)
        {
            buttonAudioSource.PlayOneShot(btnSound);
        }
    }

    // Play button
    public void PlayGame()
    {
        StartCoroutine(LoadGameAfterSound());
    }

    private IEnumerator LoadGameAfterSound()
    {
        if (buttonAudioSource != null && btnSound != null)
        {
            PlayButtonSound();
            yield return new WaitForSecondsRealtime(btnSound.length);
        }

        SceneManager.LoadSceneAsync(1);
    }
}
