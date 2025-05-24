using UnityEngine;

public class MangkokTrigger : MonoBehaviour
{
    public GameObject methBubukPrefab;

    private GameObject phosporus, pusdo, acid;
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
                if (phosporus != null && pusdo != null && acid != null)
                {
                    Destroy(phosporus);
                    Destroy(pusdo);
                    Destroy(acid);

                    Vector3 spawnPos = transform.position;
                    Instantiate(methBubukPrefab, spawnPos, Quaternion.identity);

                    phosporus = null;
                    pusdo = null;
                    timerSendok = 0f;
                    sendokDiDalam = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Phosporus"))
        {
            phosporus = other.gameObject;
        }
        else if (other.CompareTag("Psudo"))
        {
            pusdo = other.gameObject;
        }
        else if (other.CompareTag("Acid"))
        {
            acid = other.gameObject;
        }
        else if (other.CompareTag("Sendok"))
        {
            sendokDiDalam = true;
            timerSendok = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sendok"))
        {
            sendokDiDalam = false;
            timerSendok = 0f;
        }
    }
}
