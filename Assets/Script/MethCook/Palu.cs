using UnityEngine;

public class Palu : MonoBehaviour
{
    public GameObject methBlockTerovenShardPrefab;

    private GameObject methBlockTeroven;
    private Transform TransmethBlockTeroven;
    private bool methBlockTerovenDiDalam = false;
    public AudioSource hammerSound;

    void Update()
    {
        if (methBlockTerovenDiDalam)
        {
            Destroy(methBlockTeroven);

            Vector3 baseSpawnPos = TransmethBlockTeroven.position;

            for (int i = 0; i < 25; i++)
            {
                Vector3 randomOffset = new Vector3(
                    Random.Range(-0.05f, 0.05f),
                    0f,
                    Random.Range(-0.05f, 0.05f)
                );

                Vector3 spawnPos = baseSpawnPos + randomOffset;
                Instantiate(methBlockTerovenShardPrefab, spawnPos, Quaternion.identity);
            }

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
            hammerSound.Play();
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
