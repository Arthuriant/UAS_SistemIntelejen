using UnityEngine;

public class JeseePinkman : MonoBehaviour
{
    public AudioSource JeseeSound1;
    public AudioSource JeseeSound2;
    public AudioSource JeseeSound3;

    [Tooltip("Interval between random sounds (in seconds).")]
    public float delayInSeconds = 30f;

    private float timer;

    void Start()
    {
        timer = delayInSeconds;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            PlayRandomSound();
            timer = delayInSeconds; // Reset the timer
        }
    }

    void PlayRandomSound()
    {
        int randomIndex = Random.Range(1, 4); // 1 to 3 inclusive

        switch (randomIndex)
        {
            case 1:
                JeseeSound1.Play();
                break;
            case 2:
                JeseeSound2.Play();
                break;
            case 3:
                JeseeSound3.Play();
                break;
        }
    }
}
