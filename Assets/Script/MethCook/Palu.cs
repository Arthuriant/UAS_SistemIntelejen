using UnityEngine;

public class Palu : MonoBehaviour
{
    public GameObject CoklatShardPrefab; // Drag prefab box Coklat ke sini lewat inspector

    private GameObject Coklat;
    private Transform TransCoklat;

    private bool CoklatDiDalam = false;

    void Update()
    {
        if (CoklatDiDalam)
        {
            Destroy(Coklat);

            Vector3 baseSpawnPos = TransCoklat.position;

            for (int i = 0; i < 15; i++)
            {
                Vector3 randomOffset = new Vector3(
                    0f,                          // Tidak ada variasi di X
                    0f,                          // Tidak ada variasi di Y
                    Random.Range(-0.2f, 0.2f)    // Variasi hanya di Z
                );

                Vector3 spawnPos = baseSpawnPos + randomOffset;
                Instantiate(CoklatShardPrefab, spawnPos, Quaternion.identity);
            }

            // Reset supaya tidak terus ngespawn
            Coklat = null;
            CoklatDiDalam = false;
            TransCoklat = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coklat"))
        {
            CoklatDiDalam = true;
            Coklat = other.gameObject;
            TransCoklat = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coklat"))
        {
            CoklatDiDalam = false;
        }
    }
}
