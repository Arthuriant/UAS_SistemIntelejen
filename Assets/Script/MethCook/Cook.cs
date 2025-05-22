using UnityEngine;

public class Cook : MonoBehaviour
{
    public GameObject boxHitamPrefab; // Drag prefab box ungu ke sini lewat inspector

    private GameObject ungu;
    private bool statusAktif;
    private bool unguDiDalam = false;
    private float timerUngu = 0f;
    public float waktuTunggu = 5f;
    private bool diatasBunsen = false;

    void Update()
    {
        if (unguDiDalam && statusAktif && diatasBunsen)
        {
            Debug.Log("OnProses");
            timerUngu += Time.deltaTime;

            if (timerUngu >= waktuTunggu)
            {
                Destroy(ungu);
                // Spawn box ungu di atas mangkok
                Vector3 spawnPos = transform.position + Vector3.up * 1f;
                Instantiate(boxHitamPrefab, spawnPos, Quaternion.identity);

                // Reset supaya tidak terus ngespawn
                ungu = null;
                timerUngu = 0f;
                unguDiDalam = false;

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Masuk collider dengan objek: " + other.name + " | Tag: " + other.tag);
        
        if (other.CompareTag("Ungu"))
        {
            Debug.Log("Ungu terdeteksi");
            unguDiDalam = true;
            ungu = other.gameObject;
        }
        else if (other.CompareTag("Bunsen"))
        {
            Debug.Log("Bunsen terdeteksi");
            diatasBunsen = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ungu"))
        {
            unguDiDalam = false;
            timerUngu = 0f; // batalkan proses
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
