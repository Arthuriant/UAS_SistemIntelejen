using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject methHasilOven; 
    public AudioSource ovenMusic;
    public AudioSource ringMusic;
    public GameObject pencahayaanOven;
    private GameObject methHasilReshapeNampan;

    public TextMeshProUGUI text;

    private bool methReshapeDiDalam = false;
    private bool didalamOven = false;

    private float timermethInput = 0f;
    public float waktuTunggu = 5f;
    private Vector3 spawnPos;

    private bool ovenMusicPlaying = false; 

    void Update()
    {
        if (methReshapeDiDalam && didalamOven)
        {
            
            if (!ovenMusicPlaying)
            {
                ovenMusic.Play();
                ovenMusicPlaying = true;
            }

            pencahayaanOven.SetActive(true);
            timermethInput += Time.deltaTime;

            float waktuSisa = Mathf.Ceil(waktuTunggu - timermethInput);
            waktuSisa = Mathf.Max(0, waktuSisa);

      
            int menit = Mathf.FloorToInt(waktuSisa / 60f);
            int detik = Mathf.FloorToInt(waktuSisa % 60f);
            text.text = string.Format("{0:00}:{1:00}", menit, detik);

            if (timermethInput >= waktuTunggu)
            {
                if (methHasilReshapeNampan != null)
                    Destroy(methHasilReshapeNampan);

                ovenMusic.Stop();
                ovenMusicPlaying = false; 
                ringMusic.Play();
                pencahayaanOven.SetActive(false);

                
;
                Instantiate(methHasilOven, spawnPos, Quaternion.identity);

                // Reset
                methHasilReshapeNampan = null;
                timermethInput = 0f;
                methReshapeDiDalam = false;
                text.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBlock"))
        {
            Debug.Log("Hasil Reshape Masuk");
            methHasilReshapeNampan = other.gameObject;
            methReshapeDiDalam = true;
            spawnPos = other.transform.position;
        }
        else if (other.CompareTag("nampan"))
        {
            Debug.Log("Nampan Masuk Oven");
            didalamOven = true;


        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBlock"))
        {
            methHasilReshapeNampan = null;
            methReshapeDiDalam = false;
        }
        else if (other.CompareTag("nampan"))
        {
            didalamOven = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("methBlock") && !methReshapeDiDalam)
        {
            Debug.Log("Hasil Reshape tetap di dalam (OnTriggerStay)");
            methHasilReshapeNampan = other.gameObject;
            methReshapeDiDalam = true;
        }

        if (other.CompareTag("nampan") && !didalamOven)
        {
            Debug.Log("Masih di dalam oven (OnTriggerStay)");
            didalamOven = true;
        }
    }


}
