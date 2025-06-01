using UnityEngine;

public class Cook : MonoBehaviour
{
    public GameObject methBubukTermasak;

    private GameObject methBubuk;
    private bool statusAktif;
    private bool methBubukDiDalam = false;
    private float timermethBubuk = 0f;
    public float waktuTunggu = 5f;
    private bool diatasBunsen = false;

    void Update()
    {
        if (methBubukDiDalam && statusAktif && diatasBunsen)
        {
            Debug.Log("OnProses");
            timermethBubuk += Time.deltaTime;

            if (timermethBubuk >= waktuTunggu)
            {
                Destroy(methBubuk);
                Vector3 spawnPos = transform.position;
                Instantiate(methBubukTermasak, spawnPos, Quaternion.identity);

                methBubuk = null;
                timermethBubuk = 0f;
                methBubukDiDalam = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Masuk collider dengan objek: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBubuk"))
        {
            Debug.Log("methBubuk terdeteksi");
            methBubukDiDalam = true;
            methBubuk = other.gameObject;
        }
        else if (other.CompareTag("Bunsen"))
        {
            Debug.Log("Bunsen terdeteksi");
            diatasBunsen = true;
        }
        else if (other.CompareTag("apiBunsen"))
        {
            KomporAktif();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("methBubuk"))
        {
            methBubukDiDalam = false;
            timermethBubuk = 0f;
        }
        else if (other.CompareTag("apiBunsen"))
        {
            KomporMati();
        }

    }


    public void KomporAktif()
    {
        print("bunsen aktif");
        statusAktif = true;
    }

    public void KomporMati()
    {
        print("bunsen mati");
        statusAktif = false;
    }
}
