using UnityEngine;

public class Palu : MonoBehaviour
{
    public GameObject methBlockTerovenShardPrefab; // Drag prefab box methBlockTeroven ke sini lewat inspector

    private GameObject methBlockTeroven;
    private Transform TransmethBlockTeroven;

    private bool methBlockTerovenDiDalam = false;

    void Update()
    {
        if (methBlockTerovenDiDalam)
        {
            Destroy(methBlockTeroven);

            Vector3 baseSpawnPos = TransmethBlockTeroven.position + Vector3.up * 1f;

            for (int i = 0; i < 15; i++)
            {
                Vector3 randomOffset = new Vector3(
                    0f,                          // Tidak ada variasi di X
                    0f,                          // Tidak ada variasi di Y
                    Random.Range(-0.3f, 0.3f)    // Variasi hanya di Z
                );

                Vector3 spawnPos = baseSpawnPos + randomOffset;
                Instantiate(methBlockTerovenShardPrefab, spawnPos, Quaternion.identity);
            }

            // Reset supaya tidak terus ngespawn
            methBlockTeroven = null;
            methBlockTerovenDiDalam = false;
            TransmethBlockTeroven = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("methBlockTeroven"))
        {
            methBlockTerovenDiDalam = true;
            methBlockTeroven = other.gameObject;
            TransmethBlockTeroven = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("methBlockTeroven"))
        {
            methBlockTerovenDiDalam = false;
        }
    }
}
