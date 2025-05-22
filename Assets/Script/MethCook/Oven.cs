using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject boxCoklatPrefab; // Drag prefab box hitam ke sini lewat inspector

    private GameObject hitam;
    public TextMeshPro text;

    private bool hitamDiDalam = false;
    private float timerhitam = 0f;
    public float waktuTunggu = 5f;

    void Update()
    {
        if (hitamDiDalam)
        {
            timerhitam += Time.deltaTime;

            // Hitung waktu mundur
            float waktuSisa = Mathf.Ceil(waktuTunggu - timerhitam);
            waktuSisa = Mathf.Max(0, waktuSisa); // Biar gak negatif
            text.text = waktuSisa.ToString("0");

            if (timerhitam >= waktuTunggu)
            {
                Destroy(hitam);
                // Spawn box hitam di atas mangkok
                Vector3 spawnPos = transform.position + Vector3.up * 1f;
                Instantiate(boxCoklatPrefab, spawnPos, Quaternion.identity);

                // Reset supaya tidak terus ngespawn
                hitam = null;
                timerhitam = 0f;
                hitamDiDalam = false;
                text.text = ""; // Kosongkan tulisan setelah selesai
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitam"))
        {
            hitamDiDalam = true;
            hitam = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hitam"))
        {
            hitamDiDalam = false;
            timerhitam = 0f; // batalkan proses
            text.text = ""; // Kosongkan tulisan jika keluar
        }
    }
}
