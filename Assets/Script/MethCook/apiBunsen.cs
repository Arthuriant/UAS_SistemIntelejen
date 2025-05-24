using UnityEngine;

public class apiBunsen : MonoBehaviour
{
    public GameObject objectApiBunsen;
    public AudioSource apiSound; 

    public void aktifApi()
    {
        if (objectApiBunsen != null)
        {
            objectApiBunsen.SetActive(true);
        }

        if (apiSound != null && !apiSound.isPlaying)
        {
            apiSound.Play();
        }
    }

    public void matiApi()
    {
        if (objectApiBunsen != null)
        {
            objectApiBunsen.SetActive(false);
        }

        if (apiSound != null && apiSound.isPlaying)
        {
            apiSound.Stop();
        }
    }
}
