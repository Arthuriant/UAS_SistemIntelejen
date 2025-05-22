using UnityEngine;

public class MangkokTrigger : MonoBehaviour
{
    public GameObject boxUnguPrefab; // Drag prefab box ungu ke sini lewat inspector

    private GameObject merah, biru, hijau;
    private bool sendokDiDalam = false;
    private float timerSendok = 0f;
    public float waktuTunggu = 5f;

    void Update()
    {
        if (sendokDiDalam)
        {
            timerSendok += Time.deltaTime;

            if (timerSendok >= waktuTunggu)
            {
                if (merah != null && biru != null && hijau != null)
                {
                    Destroy(merah);
                    Destroy(biru);
                    Destroy(hijau);

                    // Spawn box ungu di atas mangkok
                    Vector3 spawnPos = transform.position;
                    Instantiate(boxUnguPrefab, spawnPos, Quaternion.identity);

                    // Reset supaya tidak terus ngespawn
                    merah = null;
                    biru = null;
                    timerSendok = 0f;
                    sendokDiDalam = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Merah"))
        {
            merah = other.gameObject;
        }
        else if (other.CompareTag("Biru"))
        {
            biru = other.gameObject;
        }
        else if (other.CompareTag("Hijau"))
        {
            hijau = other.gameObject;
        }
        else if (other.CompareTag("Sendok"))
        {
            sendokDiDalam = true;
            timerSendok = 0f; // mulai hitung waktu dari awal
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sendok"))
        {
            sendokDiDalam = false;
            timerSendok = 0f; // batalkan proses
        }
    }
}
